using System;
using System.Collections.Generic;

#nullable disable

namespace SharedWorkplace.Models
{
    public partial class Device
    {
        public Device()
        {
            Desks = new HashSet<Desk>();
        }

        public int Id { get; set; }
        public string Device1 { get; set; }
        public int? TableId { get; set; }

        public virtual ICollection<Desk> Desks { get; set; }
    }
}
