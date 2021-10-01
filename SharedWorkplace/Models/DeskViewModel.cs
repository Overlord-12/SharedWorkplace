using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models
{
    public class DeskViewModel : Desk
    {
        [Remote(action: "CheckDesk", controller: "Desk", ErrorMessage = "Such a table is already in use")]
        public string DeskName { get; set; }
    }
}
