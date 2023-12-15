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

namespace CourseManager.Pages.UserManagement.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _context;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public CreateModel(IUserService context, IMapper mapper, IRoleService roleService)
        {
            _context = context;
            _mapper = mapper;
            _roleService = roleService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["RoleId"] = new SelectList(await _roleService.GetAll(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public UserViewModel User { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || await _context.GetAll() == null || User == null)
            {
                return Page();
            }

            await _context.Add(_mapper.Map<User>(User));

            return RedirectToPage("./Index");
        }
    }
}
