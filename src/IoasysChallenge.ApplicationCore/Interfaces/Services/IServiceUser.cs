using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.ApplicationCore.Interfaces.Services
{
    public interface IServiceUser
    {
        Task Add(User user);
        Task Update(User user);
        Task Delete(User user);
        Task<User> GetById(int id);
        Task<User> GetByName(string username);
        Task<User> Authenticate(User user );
        Task<IEnumerable<User>> List(PaginationViewModel viewModel);
        //Task<IEnumerable<User>> FindAll();
        Task<int> CountUsers();

    }
}
