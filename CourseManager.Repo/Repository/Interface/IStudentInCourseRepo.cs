using CourseManager.Repo.Models;

namespace CourseManager.Repo.Repository.Interface
{
    public interface IStudentInCourseRepo : IGenericRepo<StudentInCourse> {
        bool CheckStudentInCourse(int studentId,int courseId);
        bool CheckStudentInCourse(string studentName,int courseId);
    }
}
