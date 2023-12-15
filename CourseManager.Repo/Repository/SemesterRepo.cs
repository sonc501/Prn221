using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;

namespace CourseManager.Repo.Repository
{
    public class SemesterRepo : GenericRepo<Semester>, ISemesterRepo
    {
        public SemesterRepo(CourseManagerDBContext context) : base(context)
        {
        }
    }
}
