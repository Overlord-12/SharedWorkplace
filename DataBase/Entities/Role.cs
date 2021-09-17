using System;
using System.Collections.Generic;

#nullable disable

namespace SharedWorkplace.Models
{
    public partial class Role
    {

        public int Id { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
