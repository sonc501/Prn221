using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;

namespace CourseManager.Repo.Repository
{
    public class RoleRepo : GenericRepo<Role>, IRoleRepo
    {
        public RoleRepo(CourseManagerDBContext context) : base(context)
        {
        }
    }
}
