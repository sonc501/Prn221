using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseManager.Repo.Models;
using AutoMapper;
using CourseManager.Service.Interfaces;
using CourseManager.Service.ViewModels;

namespace CourseManager.Pages.CourseManagement.StudentInCourses
{
    public class EditModel : PageModel
    {
        private readonly IStudentInCourseService _context;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public EditModel(IStudentInCourseService context, IMapper mapper, ICourseService courseService, IStudentService studentService)
        {
            _context = context;
            _mapper = mapper;
            _courseService = courseService;
            _studentService = studentService;
        }

        [BindProperty]
        public StudentInCourseViewModel StudentInCourse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var studentInCourse = await _context.Get(u=>u.Id==id,x=>x.Course, y=>y.Student);
            if (studentInCourse == null)
            {
                return NotFound();
            }
            StudentInCourse = _mapper.Map<StudentInCourseViewModel>(studentInCourse);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _context.Update(_mapper.Map<CourseManager.Repo.Models.StudentInCourse> (StudentInCourse));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StudentInCourseExists(StudentInCourse.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index", new { courseId = StudentInCourse.CourseId});
        }

        private async Task<bool> StudentInCourseExists(int id)
        {
            return (await _context.GetById(id) != null);
        }
    }
}
