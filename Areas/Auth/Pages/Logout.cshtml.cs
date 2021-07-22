using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorLogin.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly AuthService _authService;
        [BindProperty]
        public string Msg { get; set; } = "Logout Success";
        public LogoutModel(AuthService authService)
        {
            _authService = authService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/Login");
        }
        
    
    }
}
