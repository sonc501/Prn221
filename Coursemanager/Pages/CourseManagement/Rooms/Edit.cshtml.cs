using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseManager.Repo.Models;
using CourseManager.Service.ViewModels;
using CourseManager.Service.Interfaces;
using AutoMapper;

namespace CourseManager.Pages.Rooms
{
    public class EditModel : PageModel
    {
        private readonly IRoomService _context;
        private readonly IMapper _mapper;

        public EditModel(IRoomService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public RoomViewModel Room { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var room =  await _context.GetById((int)id);
            if (room == null)
            {
                return NotFound();
            }
            Room = _mapper.Map<RoomViewModel>(room);
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
                await _context.Update(_mapper.Map<Room>(Room));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RoomExists(Room.Id))
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

        private async Task<bool> RoomExists(int id)
        {
          return (await _context.GetById(id)!= null);
        }
    }
}
