using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models.Repository
{
    public interface IRoleRepository
    {
        public IEnumerable<Role> GetAllRole();
    }
}
