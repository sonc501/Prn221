using CourseManager.Repo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Repo.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public IAttendanceRepo AttendanceRepo { get; }
        public ICourseRepo CourseRepo { get; }
        public IMajorRepo MajorRepo { get; }
        public IRoleRepo RoleRepo { get; }
        public IRoomRepo RoomRepo { get; }
        public ISemesterRepo SemesterRepo { get; }
        public ISessionRepo SessionRepo { get; }
        public IStudentInCourseRepo StudentInCourseRepo { get; }
        public IStudentRepo StudentRepo { get; }
        public ISubjectRepo SubjectRepo { get; }
        public IUserRepo UserRepo { get; }
        public Task<int> SaveChangeAsync();
    }
}
