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

namespace CourseManager.Pages.Majors
{
    public class DetailsModel : PageModel
    {
        private readonly IMajorService _context;
        private readonly IMapper _mapper;

        public DetailsModel(IMajorService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

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
    }
}
