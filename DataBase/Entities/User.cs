using DataBase.Entities;
using System;
using System.Collections.Generic;

namespace SharedWorkplace.Models
{
    public partial class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }    

        public string Password { get; set; }

        public int? RoleId { get; set; }

        public Role Role { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public User()
        {
            Reservations = new List<Reservation>();
        }
    }
}
