﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SharedWorkplace.Models
{
    public partial class User
    {
        public User()
        {
            UserTables = new HashSet<UserTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
