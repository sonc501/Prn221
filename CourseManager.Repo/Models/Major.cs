using System;
using System.Collections.Generic;

#nullable disable

namespace CourseManager.Repo.Models
{
    public partial class Major:BaseEntity
    {
        public Major()
        {
            Students = new HashSet<Student>();
            Subjects = new HashSet<Subject>();
        }

        public string Name { get; set; }
        public string Desciption { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
