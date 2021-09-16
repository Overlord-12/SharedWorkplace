using System;
using System.Collections.Generic;

#nullable disable

namespace SharedWorkplace.Models
{
    public partial class Desk
    {
        public int Id { get; set; }
        public string TableId { get; set; }
        public string NameTable { get; set; }
        public int? DeviceId { get; set; }

        public virtual Device Device { get; set; }
    }
}
