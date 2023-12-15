using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseManager.Repo.Models;

#nullable disable

namespace CourseManager.Service.ViewModels
{
    public partial class CourseViewModel : BaseEntity
    {
        public CourseViewModel()
        {
            Sessions = new HashSet<SessionViewModel>();
            StudentInCourses = new HashSet<StudentInCourseViewModel>();
        }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int SessionCount { get; set; }
        public int SemesterId { get; set; }
        public int SubjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual SemesterViewModel Semester { get; set; }
        public virtual SubjectViewModel Subject { get; set; }
        public virtual ICollection<SessionViewModel> Sessions { get; set; }
        public virtual ICollection<StudentInCourseViewModel> StudentInCourses { get; set; }
    }
}
