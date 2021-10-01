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
        [Remote(action: "CheckDevice", controller: "Desk", ErrorMessage = "Such a device already exists")]
        public string DeviceName { get; set; }

    }
}
