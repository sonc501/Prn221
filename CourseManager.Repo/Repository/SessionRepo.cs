using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;

namespace CourseManager.Repo.Repository
{
    public class SessionRepo : GenericRepo<Session>, ISessionRepo
    {
        public SessionRepo(CourseManagerDBContext context) : base(context)
        {
        }
    }
}
