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

namespace CourseManager.Pages.Semesters
{
    public class DeleteModel : PageModel
    {
        private readonly ISemesterService _context;
        private readonly IMapper _mapper;
        public DeleteModel(ISemesterService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public SemesterViewModel Semester { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var semester = await _context.GetById((int)id);

            if (semester == null)
            {
                return NotFound();
            }
            else
            {
                Semester = _mapper.Map<SemesterViewModel>(semester);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }
            var semester = await _context.GetById((int)id);

            if (semester != null)
            {
                await _context.Delete(semester);
                Semester = _mapper.Map<SemesterViewModel>(semester);
            }

            return RedirectToPage("./Index");
        }
    }
}
