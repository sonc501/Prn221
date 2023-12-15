using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Repo.Repository
{
    public class StudentInCourseRepo : GenericRepo<StudentInCourse>, IStudentInCourseRepo
    {
        public StudentInCourseRepo(CourseManagerDBContext context) : base(context)
        {
        }

        public bool CheckStudentInCourse(int studentId, int courseId)
        {
            return _dbSet.Any(u => u.StudentId == studentId && u.CourseId == courseId);
        }

        public bool CheckStudentInCourse(string studentName, int courseId)
        {
            return _dbSet.Any(u => u.Student.Name==studentName && u.CourseId == courseId);
        }
    }
}
