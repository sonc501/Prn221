using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;

namespace CourseManager.Repo.Repository
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(CourseManagerDBContext context) : base(context)
        {
        }
    }
}
