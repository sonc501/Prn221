using System;
using System.Collections.Generic;

#nullable disable

namespace CourseManager.Repo.Models
{
    public partial class StudentInCourse:BaseEntity
    {
        public StudentInCourse()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
