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

namespace CourseManager.Pages.Semesters
{
    public class EditModel : PageModel
    {
        private readonly ISemesterService _context;
        private readonly IMapper _mapper;

        public EditModel(ISemesterService context, IMapper mapper)
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
            Semester = _mapper.Map<SemesterViewModel>(semester);
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
                await _context.Update(_mapper.Map<Semester>(Semester));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SemesterExists(Semester.Id))
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

        private async Task<bool> SemesterExists(int id)
        {
            return (await _context.GetById(id) != null);
        }
    }
}
