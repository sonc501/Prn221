using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;

namespace CourseManager.Repo.Repository
{
    public class CourseRepo : GenericRepo<Course>, ICourseRepo
    {
        public CourseRepo(CourseManagerDBContext context) : base(context)
        {
        }
    }
}
