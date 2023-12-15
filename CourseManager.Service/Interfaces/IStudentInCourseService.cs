using CourseManager.Repo.Models;
using CourseManager.Service.ViewModels;

namespace CourseManager.Service.Interfaces
{
    public interface IStudentInCourseService : IService<StudentInCourse> {
        bool CheckStudentInCourse(int studentId,int courseId);
        bool CheckStudentInCourse(string studentName, int courseId);
    }
}
