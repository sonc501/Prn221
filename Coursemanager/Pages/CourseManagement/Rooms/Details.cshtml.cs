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

namespace CourseManager.Pages.Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly IRoomService _context;
        private readonly IMapper _mapper;

        public DetailsModel(IRoomService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public RoomViewModel Room { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll()== null)
            {
                return NotFound();
            }

            var room = await _context.GetById((int)id);
            if (room == null)
            {
                return NotFound();
            }
            else 
            {
                Room = _mapper.Map<RoomViewModel>(room);
            }
            return Page();
        }
    }
}
