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

namespace CourseManager.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentService _context;
        private readonly IMapper _mapper;

        public IndexModel(IStudentService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<StudentViewModel> Student { get; set; } = default!;
        public Pagination<StudentViewModel> Pagination { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task OnGetAsync(int? index)
        {
            SearchString = (SearchString ?? "").Trim().ToLower();
            var pagination = await _context.GetByPage(x => x.Name.ToLower().Contains(SearchString), index ?? 0, 3,x=>x.Major);
            if (pagination != null)
            {
                Pagination = _mapper.Map<Pagination<StudentViewModel>>(pagination);
                Student = Pagination.Items.OrderBy(x => x.Name).ToList();
            }

        }
    }
}
