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
using IoasysChallenge.Infrastructure.Cryptography;

namespace IoasysChallenge.Infrastructure.Repositories
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(ImdbContext _repository) 
            : base(_repository)
        {

        }

        public async Task<User> Authenticate(User user)
        {

            string passwordString = MD5Cryptography.Md5Hash(user.Password);

            return await _repository.Users.Where(u => u.UserName.Equals(user.UserName) &&  u.Password.Equals(passwordString)).SingleOrDefaultAsync();
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
            return await _repository.Users.UsersActive().OrderBy(u => u.UserName).Skip(viewModel.Start).Take(viewModel.Limit).ToListAsync();
        }

        public async override Task Add(User user)
        {

            user.Password =  MD5Cryptography.Md5Hash(user.Password);

            await _repository.Users.AddAsync(user);
            await _repository.SaveChangesAsync();

        }
    }
}
