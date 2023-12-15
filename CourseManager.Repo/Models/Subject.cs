using System;
using System.Collections.Generic;

#nullable disable

namespace CourseManager.Repo.Models
{
    public partial class Subject:BaseEntity
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int MajorId { get; set; }

        public virtual Major Major { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
