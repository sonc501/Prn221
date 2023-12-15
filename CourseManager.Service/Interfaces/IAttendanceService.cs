using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Service.ViewModels;

namespace CourseManager.Service.Interfaces
{
    public interface IAttendanceService : IService<Attendance> {
        Task<Pagination<Attendance>> LoadSession(int sessionId, int pageIndex = 0, int pageSize = 10);
    }
}
