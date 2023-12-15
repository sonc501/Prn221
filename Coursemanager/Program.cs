using CourseManager.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public class Program
    {
        public const string ADMIN_POLICY = "AdminPolicy";
        public const string LECTURER_POLICY = "LecturerPolicy";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddService(builder.Configuration.GetConnectionString("DatabaseConnection")); 
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(ADMIN_POLICY, policy => policy.RequireRole("Admin"));
                options.AddPolicy(LECTURER_POLICY, policy => policy.RequireRole("Admin","Lecturer"));
            }); 
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = new PathString("/Login");
                    options.AccessDeniedPath = new PathString("/AccessDenied");
                });
            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/UserManagement", ADMIN_POLICY);
                options.Conventions.AuthorizeFolder("/CourseManagement/Majors", ADMIN_POLICY);
                options.Conventions.AuthorizeFolder("/CourseManagement/Rooms", ADMIN_POLICY);
                options.Conventions.AuthorizeFolder("/CourseManagement/Semesters", ADMIN_POLICY);
                options.Conventions.AuthorizeFolder("/CourseManagement/Students", ADMIN_POLICY);
                options.Conventions.AuthorizeFolder("/CourseManagement/Subjects", ADMIN_POLICY);
                options.Conventions.AuthorizeFolder("/CourseManagement/Courses", LECTURER_POLICY);
                options.Conventions.AuthorizePage("/CourseManagement/Courses/Create", ADMIN_POLICY);
                options.Conventions.AuthorizePage("/CourseManagement/Courses/Edit", ADMIN_POLICY);
                options.Conventions.AuthorizePage("/CourseManagement/Courses/Delete", ADMIN_POLICY);
                options.Conventions.AuthorizeFolder("/CourseManagement/Sessions", LECTURER_POLICY);
                options.Conventions.AuthorizePage("/CourseManagement/Sessions/Create", ADMIN_POLICY);
                options.Conventions.AuthorizePage("/CourseManagement/Sessions/Edit", ADMIN_POLICY);
                options.Conventions.AuthorizePage("/CourseManagement/Sessions/Delete", ADMIN_POLICY);
                options.Conventions.AuthorizeFolder("/CourseManagement/StudentInCourses", LECTURER_POLICY);
                options.Conventions.AuthorizePage("/CourseManagement/StudentInCourses/Create", ADMIN_POLICY);
                options.Conventions.AuthorizePage("/CourseManagement/StudentInCourses/Edit", ADMIN_POLICY);
                options.Conventions.AuthorizePage("/CourseManagement/StudentInCourses/Delete", ADMIN_POLICY);
                options.Conventions.AuthorizeFolder("/UserManagement", ADMIN_POLICY);
                options.Conventions.AuthorizeFolder("/CourseManagement/Attendances", LECTURER_POLICY);
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}