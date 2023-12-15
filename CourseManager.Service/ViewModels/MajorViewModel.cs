using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseManager.Repo.Models;

#nullable disable

namespace CourseManager.Service.ViewModels
{
    public partial class MajorViewModel : BaseEntity
    {
        public MajorViewModel()
        {
            Students = new HashSet<StudentViewModel>();
            Subjects = new HashSet<SubjectViewModel>();
        }
        [Required]
        public string Name { get; set; }
        public string Desciption { get; set; }

        public virtual ICollection<StudentViewModel> Students { get; set; }
        public virtual ICollection<SubjectViewModel> Subjects { get; set; }
    }
}
