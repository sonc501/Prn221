using System;
using System.Collections.Generic;

#nullable disable

namespace CourseManager.Repo.Models
{
    public partial class Course:BaseEntity
    {
        public Course()
        {
            Sessions = new HashSet<Session>();
            StudentInCourses = new HashSet<StudentInCourse>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int SessionCount { get; set; }
        public int SemesterId { get; set; }
        public int SubjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<StudentInCourse> StudentInCourses { get; set; }
    }
}
