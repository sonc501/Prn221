using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseManager.Repo.Models;

#nullable disable

namespace CourseManager.Service.ViewModels
{
    public partial class RoomViewModel : BaseEntity
    {
        public RoomViewModel()
        {
            Sessions = new HashSet<SessionViewModel>();
        }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Capacity { get; set; }

        public virtual ICollection<SessionViewModel> Sessions { get; set; }
    }
}
