using SharedWorkplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Service
{
   public interface IRoleService
    {
        IEnumerable<Role> GetAllrole();
        Role GetRole(int id);
    }
}
