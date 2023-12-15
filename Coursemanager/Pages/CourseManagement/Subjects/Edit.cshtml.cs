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

namespace CourseManager.Pages.Subjects
{
    public class EditModel : PageModel
    {
        private readonly ISubjectService _context;
        private readonly IMajorService _majorService;
        private readonly IMapper _mapper;

        public EditModel(ISubjectService context, IMapper mapper, IMajorService majorService)
        {
            _context = context;
            _mapper = mapper;
            _majorService = majorService;
        }

        [BindProperty]
        public SubjectViewModel Subject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var subject = await _context.GetById((int)id);
            if (subject == null)
            {
                return NotFound();
            }
            Subject = _mapper.Map<SubjectViewModel>(subject);
            ViewData["MajorId"] = new SelectList(await _majorService.GetAll(), "Id", "Name");
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
                await _context.Update(_mapper.Map<Subject>(Subject));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SubjectExists(Subject.Id))
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

        private async Task<bool> SubjectExists(int id)
        {
            return (await _context.GetById(id) != null);
        }
    }
}
