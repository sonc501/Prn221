using System;
using System.Collections.Generic;

#nullable disable

namespace CourseManager.Repo.Models
{
    public partial class Room:BaseEntity
    {
        public Room()
        {
            Sessions = new HashSet<Session>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? Capacity { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
