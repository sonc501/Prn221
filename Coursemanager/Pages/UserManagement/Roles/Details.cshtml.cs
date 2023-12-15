using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManager.Repo.Models;

namespace CourseManager.Pages.UserManagement.Roles
{
    public class DetailsModel : PageModel
    {
        private readonly CourseManager.Repo.Models.CourseManagerDBContext _context;

        public DetailsModel(CourseManager.Repo.Models.CourseManagerDBContext context)
        {
            _context = context;
        }

      public Role Role { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            else 
            {
                Role = role;
            }
            return Page();
        }
    }
}
