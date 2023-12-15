using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseManager.Repo.Models;
using CourseManager.Service.ViewModels;
using CourseManager.Service.Interfaces;
using AutoMapper;

namespace CourseManager.Pages.Rooms
{
    public class CreateModel : PageModel
    {
        private readonly IRoomService _context;
        private readonly IMapper _mapper;

        public CreateModel(IRoomService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RoomViewModel Room { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || await _context.GetAll() == null || Room == null)
            {
                return Page();
            }

            await _context.Add(_mapper.Map<Room>(Room));

            return RedirectToPage("./Index");
        }
    }
}
