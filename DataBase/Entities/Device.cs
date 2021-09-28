using DataBase.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedWorkplace.Models
{
    public partial class Device
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public virtual ICollection<Desk> Desks { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Device()
        {
            Desks = new List<Desk>();
            Reservations = new List<Reservation>();
        }
    }
}
