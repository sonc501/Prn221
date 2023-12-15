using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Repo.Repository.Interface
{
    public interface IAttendanceRepo : IGenericRepo<Attendance>
    {
        Task<Pagination<Attendance>> LoadSession(int sessionId, int pageIndex = 0, int pageSize = 10);
    }
}
