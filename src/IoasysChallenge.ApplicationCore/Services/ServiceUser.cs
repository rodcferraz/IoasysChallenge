using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.Interfaces.Repositories;
using IoasysChallenge.ApplicationCore.Interfaces.Services;
using IoasysChallenge.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.ApplicationCore.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IUserRepository _userRepository;
        public ServiceUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Add(User user)
        {
            await _userRepository.Add(user);
        }

        public async Task Delete(User user)
        {
            user.IsDeleted = true;
            await _userRepository.Delete(user);
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task Update(User user)
        {       
            await _userRepository.Update(user);
        }

        public async Task<User> GetByName(string username)
        {
           return await  _userRepository.GetByName(u => u.UserName.Equals(username) && u.IsDeleted != null);
        }

        public async Task<User> Authenticate(User user)
        {
            return await _userRepository.Authenticate(user);
        }

        public async Task<IEnumerable<User>> List(PaginationViewModel viewModel)
        {
            return await _userRepository.List(viewModel);
        }

        public async Task<int> CountUsers()
        {
            return await _userRepository.CountUsers();
        }

    }
}
