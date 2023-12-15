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

namespace CourseManager.Pages.UserManagement.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _context;
        private readonly IMapper _mapper;
        public DeleteModel(IUserService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public UserViewModel User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }

            var user = await _context.Get(u => u.Id == id,x=>x.Role);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = _mapper.Map<UserViewModel>(user);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || await _context.GetAll() == null)
            {
                return NotFound();
            }
            var user = await _context.GetById((int)id);

            if (user != null)
            {
                await _context.Delete(user);
                User = _mapper.Map<UserViewModel>(user);
            }

            return RedirectToPage("./Index");
        }
    }
}
