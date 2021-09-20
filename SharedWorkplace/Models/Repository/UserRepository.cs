using DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private BoardContext _context;
        public UserRepository(BoardContext board)
        {
            _context = board;
        }
        public  User AddAsync(RegisterModel model)
        {
            User user = _context.Users.FirstOrDefault(u => u.Login == model.Email);
                // добавляем пользователя в бд
                user = new User { Login = model.Email, Password = model.Password, Name = model.Name };
                Role userRole =  _context.Roles.FirstOrDefault(r => r.RoleName == "user");
                if (userRole != null)
                    user.Role = userRole;
                _context.Users.Add(user);
                _context.SaveChangesAsync();
            return user;
        }
        public User FindUser(string Login)
        {
            User user = _context.Users.FirstOrDefault(u => u.Login == Login);
            return user;
        }
        public IEnumerable<User> GetAllUser()
        {
            return _context.Users;
        }
        public  User LoginAsync(LoginModel model)
        {
            var password = _context.Users.FirstOrDefault(t => t.Login == model.Email).Password;
            User user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Login == model.Email && password == model.Password);
            return user;
        }
    }
}
