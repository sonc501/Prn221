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

namespace CourseManager.Pages.Sessions
{
    public class EditModel : PageModel
    {
        private readonly ISessionService _context; 
        private readonly ICourseService _courseService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public EditModel(ISessionService context, IMapper mapper, ICourseService courseService, IRoomService roomService)
        {
            _context = context;
            _mapper = mapper;
            _courseService = courseService;
            _roomService = roomService;
        }

        [BindProperty]
        public SessionViewModel Session { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var session = await _context.GetById((int)id);
            if (session == null)
            {
                return NotFound();
            }
            Session = _mapper.Map<SessionViewModel>(session);
           ViewData["CourseId"] = new SelectList(await _courseService.GetAll(), "Id", "Name");
           ViewData["RoomId"] = new SelectList(await _roomService.GetAll(), "Id", "Name");
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
                await _context.Update(_mapper.Map<Session>(Session));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SessionExists(Session.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { courseId = Session.CourseId });
        }

        private async Task<bool> SessionExists(int id)
        {
            return (await _context.GetById(id) != null);
        }
    }
}
