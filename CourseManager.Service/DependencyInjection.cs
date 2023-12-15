using AutoMapper;
using CourseManager.Repo.Models;
using CourseManager.Repo.Repository;
using CourseManager.Repo.Repository.Interface;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using CourseManager.Service.Mappers;
using CourseManager.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services, string databaseConnection)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #region Services
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ISemesterService, SemesterService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IStudentInCourseService, StudentInCourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));
            #endregion
            #region Repositories
            services.AddScoped<IAttendanceRepo, AttendanceRepo>();
            services.AddScoped<ICourseRepo, CourseRepo>();
            services.AddScoped<IMajorRepo, MajorRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IRoomRepo, RoomRepo>();
            services.AddScoped<ISemesterRepo, SemesterRepo>();
            services.AddScoped<ISessionRepo, SessionRepo>();
            services.AddScoped<IStudentInCourseRepo, StudentInCourseRepo>();
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<ISubjectRepo, SubjectRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            #endregion
            services.AddDbContext<CourseManagerDBContext>(option => option.UseSqlServer(databaseConnection).EnableSensitiveDataLogging(), ServiceLifetime.Scoped);
            services.AddScoped<CourseManagerDBContext>();
            services.AddAutoMapper(typeof(MapperConfigurationsProfile).Assembly);
            services.AddScoped<IMapper, Mapper>();
            return services;
        }
    }
}
