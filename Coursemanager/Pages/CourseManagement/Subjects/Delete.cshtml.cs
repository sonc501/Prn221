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

namespace CourseManager.Pages.Subjects
{
    public class DeleteModel : PageModel
    {
        private readonly ISubjectService _context;
        private readonly IMapper _mapper;
        public DeleteModel(ISubjectService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public SubjectViewModel Subject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var subject = await _context.Get(u => u.Id == id,x=>x.Major);

            if (subject == null)
            {
                return NotFound();
            }
            else
            {
                Subject = _mapper.Map<SubjectViewModel>(subject);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }
            var subject = await _context.GetById((int)id);

            if (subject != null)
            {
                await _context.Delete(subject);
                Subject = _mapper.Map<SubjectViewModel>(subject);
            }

            return RedirectToPage("./Index");
        }
    }
}
