using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorLogin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace BlazorLogin.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly AuthService _authService;
        public LoginModel(AuthService authService)
        {
            _authService = authService;
        }
        [BindProperty]
        public string Username { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";
        //public string PasswordType { get; set; } = "password";
        public string Msg { get; set; }
        public async Task OnGetAsync()
        {
            /*try
            {
                // 清除已經存在的登入 Cookie 內容
                _authService.Logout();
            }
            catch { }*/
        }
        public string ReturnUrl { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                User user = _authService.Login(Username, Password);
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserNo),
                        new Claim(ClaimTypes.Sid, user.UserId.ToString())
                    };
                var claimsIdentity = new ClaimsIdentity(
                       claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(10)
                };
                try
                {
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                    


                    return LocalRedirect("/");
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    return Page();
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return Page();
            }




        }
    }
}
