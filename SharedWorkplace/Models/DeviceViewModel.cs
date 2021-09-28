using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models
{
    public class DeviceViewModel
    {
        public int Id { get; set; }
        [Remote(action: "CheckDesk", controller: "Desk", ErrorMessage = "Такой девайс уже используется")]
        public string DeskName { get; set; }
        public virtual ICollection<Desk> Desks { get; set; }

    }
}
