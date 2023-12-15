using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;

namespace CourseManager.Repo.Repository
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        public StudentRepo(CourseManagerDBContext context) : base(context)
        {
        }
    }
}
