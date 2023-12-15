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

namespace CourseManager.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly ICourseService _context;
        private readonly ISemesterService _semesterService;
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public EditModel(ICourseService context, IMapper mapper, ISemesterService semesterService, ISubjectService subjectService)
        {
            _context = context;
            _mapper = mapper;
            _semesterService = semesterService;
            _subjectService = subjectService;
        }

        [BindProperty]
        public CourseViewModel Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var course = await _context.Get(u => u.Id == id, x => x.Semester, y => y.Subject);
            if (course == null)
            {
                return NotFound();
            }
            Course = _mapper.Map<CourseViewModel>(course);
            ViewData["SemesterId"] = new SelectList(await _semesterService.GetAll(), "Id", "Name");
            ViewData["SubjectId"] = new SelectList(await _subjectService.GetAll(), "Id", "Name");
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
                await _context.Update(_mapper.Map<Course>(Course));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CourseExists(Course.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> CourseExists(int id)
        {
            return (await _context.GetById(id) != null);
        }
    }
}
