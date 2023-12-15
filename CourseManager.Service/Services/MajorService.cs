using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Service.Services
{
    public class MajorService : Service<Major>, IMajorService
    {
        public MajorService(IUnitOfWork unitOfWork, IGenericRepo<Major> repo) : base(unitOfWork, repo)
        {
        }
    }
}
