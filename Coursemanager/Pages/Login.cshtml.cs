using CourseManager.Repo.Models;
using CourseManager.Service.Interfaces;
using CourseManager.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CourseManager.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService; 
        public LoginModel(IUserService userServices)
        {
            _userService = userServices;
        }
        [BindProperty]
        public User User { get; set; } = default!;
        public void OnGetEmail(string email)
        {
            User ??= new User();
            User.Email = email;
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var account = await _userService.Get(user=>user.Email== User.Email && user.Password==User.Password,x=>x.Role);
            if (account == null)
            {
                ModelState.AddModelError("", "Incorrect username, password");
                return Page();
            }
            var claim = new List<Claim> {
                new Claim(ClaimTypes.Role, account.Role.Name)
            };
            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            var claimIdentity = new ClaimsIdentity(claim, scheme);
            var user = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync(scheme, user);
            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            await HttpContext.SignOutAsync(scheme);
            return RedirectToPage("Login");
        }
    }
}
