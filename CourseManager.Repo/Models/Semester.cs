using System;
using System.Collections.Generic;

#nullable disable

namespace CourseManager.Repo.Models
{
    public partial class Semester:BaseEntity
    {
        public Semester()
        {
            Courses = new HashSet<Course>();
        }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
