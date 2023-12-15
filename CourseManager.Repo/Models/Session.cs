using System;
using System.Collections.Generic;

#nullable disable

namespace CourseManager.Repo.Models
{
    public partial class Session : BaseEntity
    {
        public Session()
        {
            Attendances = new HashSet<Attendance>();
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
