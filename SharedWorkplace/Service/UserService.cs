using SharedWorkplace.Models;
using SharedWorkplace.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
       
        public UserService(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public User AddAsync(RegisterModel model)
        {
            return _repository.AddAsync(model);
        }

        public User FindUser(string Login)
        {
            return _repository.FindUser(Login);
        }

        public IEnumerable<User> GetAllUser()
        {
            return _repository.GetAllUser();
        }

        public User LoginAsync(LoginModel model)
        {
            return _repository.LoginAsync(model);
        }
    }
}
