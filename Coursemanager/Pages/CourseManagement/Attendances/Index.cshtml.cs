using AutoMapper;
using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Service.Interfaces;
using CourseManager.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Pages.CourseManagement.Attendances
{
    public class IndexModel : PageModel
    {
        private readonly IAttendanceService _attendanceService;
        private readonly ISessionService _sessionService;
        private readonly IStudentInCourseService _studentInCourseService;
        private readonly IMapper _mapper;

        public IndexModel(IAttendanceService attendanceService, ISessionService sessionService, IStudentInCourseService studentInCourseService, IMapper mapper)
        {
            _attendanceService = attendanceService;
            _sessionService = sessionService;
            _studentInCourseService = studentInCourseService;
            _mapper = mapper;
        }
        [BindProperty]
        public IList<AttendanceViewModel> Attendances { get; set; }
        public Pagination<AttendanceViewModel> Pagination { get; set; }
        [BindProperty]
        public Session Session { get; set; }
        public async Task<IActionResult> OnGet(int sessionId, int? index)
        {
            Session = await _sessionService.Get(x=>x.Id==sessionId,y=>y.Course);
            if (Session==null)
            {
                return NotFound();
            }
            var pagination = await _attendanceService.LoadSession(sessionId, index ?? 0, 4);
            if (pagination != null)
            {
                Pagination = _mapper.Map<Pagination<AttendanceViewModel>>(pagination);
                Attendances = Pagination.Items.OrderBy(x=>x.StudentInCourse.StudentId).ToList();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || await _attendanceService.GetAll() == null || Attendances == null)
            {
                return Page();
            }
            var attendances = _mapper.Map<List<Attendance>>(Attendances);
            foreach(var attendance in attendances)
            {
                await _attendanceService.Update(attendance);
            }

            return RedirectToPage("/CourseManagement/Sessions/Index", new { courseId = Session.CourseId });
        }
    }
}
