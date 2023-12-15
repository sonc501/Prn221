using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManager.Repo.Models;
using AutoMapper;
using CourseManager.Service.Interfaces;
using CourseManager.Service.ViewModels;

namespace CourseManager.Pages.CourseManagement.StudentInCourses
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentInCourseService _context;
        private readonly IMapper _mapper;
        public DeleteModel(IStudentInCourseService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public StudentInCourseViewModel StudentInCourse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var studentInCourse = await _context.Get(u => u.Id == id, x => x.Course, y=>y.Student);

            if (studentInCourse == null)
            {
                return NotFound();
            }
            else
            {
                StudentInCourse = _mapper.Map<StudentInCourseViewModel>(studentInCourse);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }
            var studentInCourse = await _context.GetById((int)id);

            if (studentInCourse != null)
            {
                await _context.Delete(studentInCourse);
                StudentInCourse = _mapper.Map<StudentInCourseViewModel>(studentInCourse);
            }

            return RedirectToPage("./Index", new { courseId = StudentInCourse.CourseId }); ;
        }
    }
}
