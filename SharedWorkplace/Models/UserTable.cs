using System;
using System.Collections.Generic;

#nullable disable

namespace SharedWorkplace.Models
{
    public partial class UserTable
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan UseTime { get; set; }

        public virtual User User { get; set; }
    }
}
