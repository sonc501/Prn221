using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManager.Repo.Models;
using CourseManager.Service.ViewModels;
using CourseManager.Service.Interfaces;
using AutoMapper;

namespace CourseManager.Pages.Majors
{
    public class DeleteModel : PageModel
    {
        private readonly IMajorService _context;
        private readonly IMapper _mapper;
        public DeleteModel(IMajorService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public MajorViewModel Major { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var major = await _context.GetById((int)id);

            if (major == null)
            {
                return NotFound();
            }
            else
            {
                Major = _mapper.Map<MajorViewModel>(major);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }
            var major = await _context.GetById((int)id);

            if (major != null)
            {
                await _context.Delete(major);
                Major = _mapper.Map<MajorViewModel>(major);
            }

            return RedirectToPage("./Index");
        }
    }
}
