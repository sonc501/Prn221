using CourseManager.Repo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Repo.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } = 0;
        public BaseStatus Status { get; set; } = BaseStatus.Ok;
    }
}
