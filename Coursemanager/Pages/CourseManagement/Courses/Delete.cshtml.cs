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

namespace CourseManager.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly ICourseService _context;
        private readonly IMapper _mapper;
        public DeleteModel(ICourseService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public CourseViewModel Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var course = await _context.Get(u=>u.Id==id,x=>x.Semester,y=>y.Subject);

            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Course = _mapper.Map<CourseViewModel>(course);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }
            var course = await _context.GetById((int)id);

            if (course != null)
            {
                await _context.Delete(course);
                Course = _mapper.Map<CourseViewModel>(course);
            }

            return RedirectToPage("./Index");
        }
    }
}
