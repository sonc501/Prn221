using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManager.Repo.Models;
using AutoMapper;
using CourseManager.Repo.Commons;
using CourseManager.Service.Interfaces;
using CourseManager.Service.ViewModels;

namespace CourseManager.Pages.CourseManagement.StudentInCourses
{
    public class IndexModel : PageModel
    {
        private readonly IStudentInCourseService _context;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public IndexModel(IStudentInCourseService context, IMapper mapper, ICourseService courseService)
        {
            _context = context;
            _mapper = mapper;
            _courseService = courseService;
        }

        public IList<StudentInCourseViewModel> StudentInCourse { get; set; } = default!;
        public Pagination<StudentInCourseViewModel> Pagination { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public Course Course { get;set; }
        public async Task OnGetAsync(int courseId, int? index)
        {
            Course = await _courseService.GetById(courseId);
            SearchString = (SearchString ?? "").Trim().ToLower();
            var pagination = await _context.GetByPage(x=>x.CourseId==courseId&&x.Student.Name.ToLower().Contains(SearchString),index ?? 0, 3, x => x.Course, y=>y.Student);
            if (pagination != null)
            {
                Pagination = _mapper.Map<Pagination<StudentInCourseViewModel>>(pagination);
                StudentInCourse = Pagination.Items.OrderBy(x => x.StudentId).ToList();
            }

        }
    }
}
