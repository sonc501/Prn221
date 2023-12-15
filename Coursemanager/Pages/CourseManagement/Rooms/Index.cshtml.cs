using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManager.Repo.Models;
using CourseManager.Service.Services;
using CourseManager.Service.Interfaces;
using CourseManager.Service.ViewModels;
using AutoMapper;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Repo.Commons;

namespace CourseManager.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly IRoomService _context;
        private readonly IMapper _mapper;

        public IndexModel(IRoomService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<RoomViewModel> Room { get;set; } = default!;
        public Pagination<RoomViewModel> Pagination { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get;set; }
        public async Task OnGetAsync(int? index)
        {
            SearchString = (SearchString ?? "").Trim().ToLower();
            var pagination = await _context.GetByPage(x => x.Name.ToLower().Contains(SearchString), index ?? 0, 3);
            if (pagination != null)
            {
                Pagination = _mapper.Map<Pagination<RoomViewModel>>(pagination);
                Room = Pagination.Items.OrderBy(x => x.Name).ToList();
            }

        }
    }
}
