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

namespace CourseManager.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentService _context;
        private readonly IMajorService _majorService;
        private readonly IMapper _mapper;

        public CreateModel(IStudentService context, IMapper mapper, IMajorService majorService)
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
        public StudentViewModel Student { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || await _context.GetAll() == null || Student == null)
            {
                return Page();
            }

            await _context.Add(_mapper.Map<Student>(Student));

            return RedirectToPage("./Index");
        }
    }
}
