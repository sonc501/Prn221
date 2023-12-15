using AutoMapper;
using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Repo.Repository;
using CourseManager.Repo.Repository.Interface;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using CourseManager.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Service.Services
{
    public class RoomService : Service<Room>, IRoomService
    {

        public RoomService(IUnitOfWork unitOfWork, IGenericRepo<Room> repo) : base(unitOfWork, repo)
        {
        }

    }
}
