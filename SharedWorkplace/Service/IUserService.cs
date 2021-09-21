using SharedWorkplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
    public interface IUserService
    {
        User FindUser(string Login);
        IEnumerable<User> GetAllUser();
        User AddAsync(RegisterModel model);
        User LoginAsync(LoginModel model);
    }
}
