using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using System.Linq.Expressions;

namespace CourseManager.Service.Services
{
    public class CourseService : Service<Course>, ICourseService
    {
        public CourseService(IUnitOfWork unitOfWork, IGenericRepo<Course> repo) : base(unitOfWork, repo)
        {
        }
    }
}
