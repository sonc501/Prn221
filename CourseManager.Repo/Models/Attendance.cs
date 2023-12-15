using CourseManager.Repo.Enums;
using System;
using System.Collections.Generic;

#nullable disable

namespace CourseManager.Repo.Models
{
    public partial class Attendance:BaseEntity
    {
        public int StudentInCourseId { get; set; }
        public int SessionId { get; set; }
        public string Description { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public new AttendanceStatus Status { get; set; } = AttendanceStatus.Unchecked;

        public virtual Session Session { get; set; }
        public virtual StudentInCourse StudentInCourse { get; set; }
    }
}
