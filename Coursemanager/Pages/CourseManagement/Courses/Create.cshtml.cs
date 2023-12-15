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

namespace CourseManager.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseService _context;
        private readonly ISemesterService _semesterService;
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public CreateModel(ICourseService context, IMapper mapper, ISemesterService semesterService, ISubjectService subjectService)
        {
            _context = context;
            _mapper = mapper;
            _semesterService = semesterService;
            _subjectService = subjectService;
        }

        public async Task<IActionResult> OnGet()
        {
        ViewData["SemesterId"] = new SelectList(await _semesterService.GetAll(), "Id", "Name");
        ViewData["SubjectId"] = new SelectList(await _subjectService.GetAll(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CourseViewModel Course { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || await _context.GetAll() == null || Course == null)
            {
                return Page();
            }

            await _context.Add(_mapper.Map<Course>(Course));

            return RedirectToPage("./Index");
        }
    }
}
