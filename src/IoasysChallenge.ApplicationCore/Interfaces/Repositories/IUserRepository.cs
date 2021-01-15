using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.ApplicationCore.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByName(Expression<Func<User, bool>> predicate);
        Task<User> Authenticate(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<User>> List(PaginationViewModel viewModel);
        Task<IEnumerable<User>> GetAllUsers();
        Task<int> CountUsers();
        Task<User> GetById(int id);
        
    }
}
