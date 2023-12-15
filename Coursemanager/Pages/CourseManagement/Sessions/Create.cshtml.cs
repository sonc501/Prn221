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

namespace CourseManager.Pages.Sessions
{
    public class CreateModel : PageModel
    {
        private readonly ISessionService _context;
        private readonly ICourseService _courseService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public CreateModel(ISessionService context, IMapper mapper, ICourseService courseService, IRoomService roomService)
        {
            _context = context;
            _mapper = mapper;
            _courseService = courseService;
            _roomService = roomService;
        }
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int courseId)
        {
            Course = await _courseService.Get(u=>u.Id==courseId,x=>x.Sessions);
            if (Course == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(await _roomService.GetAll(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public SessionViewModel Session { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || await _context.GetAll() == null || Session == null)
            {
                return Page();
            }
            
            await _context.Add(_mapper.Map<Session>(Session));
            return RedirectToPage("./Index", new { courseId = Session.CourseId });
        }
    }
}
