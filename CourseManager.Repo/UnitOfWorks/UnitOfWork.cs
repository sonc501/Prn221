using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Repo.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CourseManagerDBContext _dbContext;
        public IAttendanceRepo _attendanceRepo { get; }
        public ICourseRepo _courseRepo { get; }
        public IMajorRepo _majorRepo { get; }
        public IRoleRepo _roleRepo { get; }
        public IRoomRepo _roomRepo { get; }
        public ISemesterRepo _semesterRepo { get; }
        public ISessionRepo _sessionRepo { get; }
        public IStudentInCourseRepo _studentInCourseRepo { get; }
        public IStudentRepo _studentRepo { get; }
        public ISubjectRepo _subjectRepo { get; }
        public IUserRepo _userRepo { get; }
        public UnitOfWork(CourseManagerDBContext dbContext, IAttendanceRepo attendanceRepo, ICourseRepo courseRepo, IMajorRepo majorRepo, IRoleRepo roleRepo, IRoomRepo roomRepo, ISemesterRepo semesterRepo, ISessionRepo sessionRepo, IStudentInCourseRepo studentInCourseRepo, IStudentRepo studentRepo, ISubjectRepo subjectRepo, IUserRepo userRepo)
        {
            _dbContext = dbContext;
            _attendanceRepo = attendanceRepo;
            _courseRepo = courseRepo;
            _majorRepo = majorRepo;
            _roleRepo = roleRepo;
            _roomRepo = roomRepo;
            _semesterRepo = semesterRepo;
            _sessionRepo = sessionRepo;
            _studentInCourseRepo = studentInCourseRepo;
            _studentRepo = studentRepo;
            _subjectRepo = subjectRepo;
            _userRepo = userRepo;
        }

        public IAttendanceRepo AttendanceRepo => _attendanceRepo;

        public ICourseRepo CourseRepo => _courseRepo;

        public IMajorRepo MajorRepo => _majorRepo;

        public IRoleRepo RoleRepo => _roleRepo;

        public IRoomRepo RoomRepo => _roomRepo;

        public ISemesterRepo SemesterRepo => _semesterRepo;

        public ISessionRepo SessionRepo => _sessionRepo;

        public IStudentInCourseRepo StudentInCourseRepo => _studentInCourseRepo;

        public IStudentRepo StudentRepo => _studentRepo;

        public ISubjectRepo SubjectRepo => _subjectRepo;

        public IUserRepo UserRepo => _userRepo;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
