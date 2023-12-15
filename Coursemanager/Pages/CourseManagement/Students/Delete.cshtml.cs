﻿using System;
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

namespace CourseManager.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentService _context;
        private readonly IMapper _mapper;
        public DeleteModel(IStudentService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public StudentViewModel Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var student = await _context.Get(u => u.Id == id,x=>x.Major);

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = _mapper.Map<StudentViewModel>(student);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }
            var student = await _context.GetById((int)id);

            if (student != null)
            {
                await _context.Delete(student);
                Student = _mapper.Map<StudentViewModel>(student);
            }

            return RedirectToPage("./Index");
        }
    }
}
