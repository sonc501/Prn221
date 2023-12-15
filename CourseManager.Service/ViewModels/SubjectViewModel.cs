using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseManager.Repo.Models;

#nullable disable

namespace CourseManager.Service.ViewModels
{
    public partial class SubjectViewModel : BaseEntity
    {
        public SubjectViewModel()
        {
            Courses = new HashSet<CourseViewModel>();
        }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int MajorId { get; set; }

        public virtual MajorViewModel Major { get; set; }
        public virtual ICollection<CourseViewModel> Courses { get; set; }
    }
}
