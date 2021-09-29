using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models
{
    public class ReservationViewModel
    {

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public Desk Desk { get; set; }
        public User User { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
