using System;
using System.Collections.Generic;

#nullable disable

namespace CourseManager.Repo.Models
{
    public partial class Student:BaseEntity
    {
        public Student()
        {
            StudentInCourses = new HashSet<StudentInCourse>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime EnrollDate { get; set; }
        public int MajorId { get; set; }

        public virtual Major Major { get; set; }
        public virtual ICollection<StudentInCourse> StudentInCourses { get; set; }
    }
}
