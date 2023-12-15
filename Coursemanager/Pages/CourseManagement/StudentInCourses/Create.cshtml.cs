using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseManager.Repo.Models;
using AutoMapper;
using CourseManager.Service.Interfaces;
using CourseManager.Service.ViewModels;

namespace CourseManager.Pages.CourseManagement.StudentInCourses
{
    public class CreateModel : PageModel
    {
        private readonly IStudentInCourseService _context;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public CreateModel(IStudentInCourseService context, IMapper mapper, ICourseService courseService, IStudentService studentService)
        {
            _context = context;
            _mapper = mapper;
            _courseService = courseService;
            _studentService = studentService;
        }
        public Course Course { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task<IActionResult> OnGetAsync(int courseId)
        {
            Course = await _courseService.GetById(courseId);
            if (Course == null)
            {
                return NotFound();
            }
            if (SearchString != null)
            {
                var students = (await _studentService.GetByPage(x => x.Name.Contains(SearchString.Trim()),0,5)).Items.SkipWhile(x=> _context.CheckStudentInCourse(x.Id, courseId));
                Students = _mapper.Map<List<StudentViewModel>>(students); 
            }
            //ViewData["StudentId"] = new SelectList(await _studentService.GetAll(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public StudentInCourseViewModel StudentInCourse { get; set; } = default!;
        [BindProperty]
        public IList<StudentViewModel> Students { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || await _context.GetAll() == null || StudentInCourse == null)
            {
                return Page();
            }
            if (_context.CheckStudentInCourse(StudentInCourse.StudentId, StudentInCourse.CourseId))
            {
                ModelState.AddModelError("","This student is already in the course!");
                return Page();
            }
            await _context.Add(_mapper.Map<CourseManager.Repo.Models.StudentInCourse>(StudentInCourse));

            return RedirectToPage("./Index", new { courseId = StudentInCourse.CourseId });
        }
    }
}
