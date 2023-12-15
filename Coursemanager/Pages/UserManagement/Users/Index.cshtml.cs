using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManager.Repo.Models;
using AutoMapper;
using CourseManager.Repo.Commons;
using CourseManager.Service.Interfaces;
using CourseManager.Service.ViewModels;

namespace CourseManager.Pages.UserManagement.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _context;
        private readonly IMapper _mapper;

        public IndexModel(IUserService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<UserViewModel> User { get; set; } = default!;
        public Pagination<UserViewModel> Pagination { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task OnGetAsync(int? index)
        {
            SearchString = (SearchString ?? "").Trim().ToLower();
            var pagination = await _context.GetByPage(x=>x.Username.ToLower().Contains(SearchString), index ?? 0, 3,x=>x.Role);
            if (pagination != null)
            {
                Pagination = _mapper.Map<Pagination<UserViewModel>>(pagination);
                User = Pagination.Items.OrderBy(x => x.Username).ToList();
            }

        }
    }
}
