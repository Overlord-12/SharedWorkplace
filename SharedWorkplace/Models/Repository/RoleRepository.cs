using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private BoardContext _boardContext;
        public RoleRepository(BoardContext boardContext)
        {
            _boardContext = boardContext;
        }
        public IEnumerable<Role> GetAllRole()
        {
            return _boardContext.Roles;
        }
    }
}
