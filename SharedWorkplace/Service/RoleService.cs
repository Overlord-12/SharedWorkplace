using SharedWorkplace.Models;
using SharedWorkplace.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public IEnumerable<Role> GetAllrole()
        {
            return _roleRepository.GetAllRole();
        }

        public Role GetRole(int id)
        {
            return _roleRepository.GetAllRole().FirstOrDefault(t => t.Id == id);
        }
    }
}
