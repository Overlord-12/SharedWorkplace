using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models.Repository
{
    public interface IUserRepository
    {
        User FindUser(string Login);
        IEnumerable<User> GetAllUser();
        User AddAsync(RegisterModel model);
        User LoginAsync(LoginModel model);
    }
}
