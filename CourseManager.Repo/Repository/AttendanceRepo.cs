using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Repo.Repository
{
    public class AttendanceRepo : GenericRepo<Attendance>, IAttendanceRepo
    {
        public AttendanceRepo(CourseManagerDBContext context) : base(context)
        {
        }

        public async Task<Pagination<Attendance>> LoadSession(int sessionId, int pageIndex = 0, int pageSize = 10)
        {
            var attendances = await _dbSet
                .Where(x=>x.SessionId == sessionId)
                .OrderBy(x => x.Id)
                .AsNoTracking()
                .Include(x => x.StudentInCourse)
                .ToListAsync();
            var session = await _context.Sessions.Include(x=>x.Course).Where(x=>x.Id==sessionId).AsNoTracking().FirstOrDefaultAsync();
            var studentInCourses = _context.StudentInCourses.Where(x => x.CourseId==session.CourseId).AsNoTracking().ToList();
            if (attendances==null || attendances.Count == 0)
            {
                foreach (var student in studentInCourses)
                {
                    var attendance = new Attendance()
                    {
                        StudentInCourseId = student.Id,
                        AttendanceDate = DateTime.UtcNow,
                        SessionId = sessionId,
                        Status = Enums.AttendanceStatus.Unchecked
                    };
                    await base.AddAsync(attendance);
                }
            }
            else
            {
                foreach (var student in studentInCourses)
                {
                    if (!attendances.Any(x => x.StudentInCourseId == student.Id))
                    {
                        var attendance = new Attendance()
                        {
                            StudentInCourseId = student.Id,
                            AttendanceDate = session.StartTime,
                            SessionId = sessionId,
                            Status = Enums.AttendanceStatus.Unchecked
                        };
                        await base.AddAsync(attendance);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return await ToPagination(_dbSet,x=>x.SessionId==sessionId,pageIndex,pageSize,x=>x.StudentInCourse.Student, x=>x.Session);
        }
    }
}
