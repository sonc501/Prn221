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

namespace CourseManager.Pages.Semesters
{
    public class IndexModel : PageModel
    {
        private readonly ISemesterService _context;
        private readonly IMapper _mapper;

        public IndexModel(ISemesterService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<SemesterViewModel> Semester { get; set; } = default!;
        public Pagination<SemesterViewModel> Pagination { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task OnGetAsync(int? index)
        {
            SearchString = (SearchString ?? "").Trim().ToLower();
            var pagination = await _context.GetByPage(x => x.Name.ToLower().Contains(SearchString), index ?? 0, 3);
            if (pagination != null)
            {
                Pagination = _mapper.Map<Pagination<SemesterViewModel>>(pagination);
                Semester = Pagination.Items.OrderBy(x => x.Name).ToList();
            }

        }
    }
}
