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

namespace CourseManager.Pages.Subjects
{
    public class CreateModel : PageModel
    {
        private readonly ISubjectService _context;
        private readonly IMajorService _majorService;
        private readonly IMapper _mapper;

        public CreateModel(ISubjectService context, IMapper mapper, IMajorService majorService)
        {
            _context = context;
            _mapper = mapper;
            _majorService = majorService;
        }

        public async Task<IActionResult> OnGet()
        {
        ViewData["MajorId"] = new SelectList(await _majorService.GetAll(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public SubjectViewModel Subject { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || await _context.GetAll() == null || Subject == null)
            {
                return Page();
            }

            await _context.Add(_mapper.Map<Subject>(Subject));

            return RedirectToPage("./Index");
        }
    }
}
