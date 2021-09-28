using DataBase.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SharedWorkplace.Models
{
    public partial class Desk
    {
        public int Id { get; set; }
        public string DeskName { get; set; }
        public ICollection<Device> Devices { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        public Desk()
        {
            Devices = new List<Device>();
            Reservations = new List<Reservation>();
        }
    }
}
