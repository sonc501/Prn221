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

namespace CourseManager.Pages.Sessions
{
    public class DeleteModel : PageModel
    {
        private readonly ISessionService _context;
        private readonly IMapper _mapper;
        public DeleteModel(ISessionService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public SessionViewModel Session { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var session = await _context.Get(u=>u.Id==id,x=>x.Course,y=>y.Room);

            if (session == null)
            {
                return NotFound();
            }
            else
            {
                Session = _mapper.Map<SessionViewModel>(session);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }
            var session = await _context.GetById((int)id);

            if (session != null)
            {
                await _context.Delete(session);
                Session = _mapper.Map<SessionViewModel>(session);
            }

            return RedirectToPage("./Index", new { courseId = Session.CourseId });
        }
    }
}
