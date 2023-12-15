using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;

namespace CourseManager.Repo.Repository
{
    public class RoomRepo : GenericRepo<Room>, IRoomRepo
    {
        public RoomRepo(CourseManagerDBContext context) : base(context)
        {
        }
    }
}
