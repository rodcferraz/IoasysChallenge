using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.Interfaces.Repositories;
using IoasysChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IoasysChallenge.Infrastructure.Query.Users;
using IoasysChallenge.UI.Web.ViewModels;

namespace IoasysChallenge.Infrastructure.Repositories
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(ImdbContext _repository) 
            : base(_repository)
        {

        }

        public async Task<User> Authenticate(Expression<Func<User, bool>> predicate)
        {
            var a = predicate;
            return await _repository.Users.Where(predicate).SingleOrDefaultAsync();
        }

        public async Task<int> CountUsers()
        {
            return await FindAll().CountAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _repository.Users.Where(u => u.UserId == id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> List(PaginationViewModel viewModel)
        {
            return await _repository.Users.UsersActive().Skip(viewModel.Start).Take(viewModel.Limit).OrderBy(u => u.UserName).ToListAsync();
        }
    }
}
