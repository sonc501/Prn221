using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;

namespace CourseManager.Repo.Repository
{
    public class MajorRepo : GenericRepo<Major>, IMajorRepo
    {
        public MajorRepo(CourseManagerDBContext context) : base(context)
        {
        }
    }
}
