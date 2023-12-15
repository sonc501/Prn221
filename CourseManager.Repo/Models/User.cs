using System;
using System.Collections.Generic;

#nullable disable

namespace CourseManager.Repo.Models
{
    public partial class User:BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
