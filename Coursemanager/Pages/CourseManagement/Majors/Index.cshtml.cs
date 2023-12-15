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

namespace CourseManager.Pages.Majors
{
    public class IndexModel : PageModel
    {
        private readonly IMajorService _context;
        private readonly IMapper _mapper;

        public IndexModel(IMajorService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<MajorViewModel> Major { get; set; } = default!;
        public Pagination<MajorViewModel> Pagination { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task OnGetAsync(int? index)
        {
            SearchString = (SearchString ?? "").Trim().ToLower();
            var pagination = await _context.GetByPage(x => x.Name.ToLower().Contains(SearchString), index ?? 0, 3);
            if (pagination != null)
            {
                Pagination = _mapper.Map<Pagination<MajorViewModel>>(pagination);
                Major = Pagination.Items.OrderBy(x => x.Name).ToList();
            }

        }
    }
}
