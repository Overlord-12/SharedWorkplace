using SharedWorkplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Reservation
    {

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public ICollection<Device> Devices { get; set; }
        public Desk Desk { get; set; }
        public User User { get; set; }
        public Reservation()
        {
            Devices = new List<Device>();
        }
    }
}
