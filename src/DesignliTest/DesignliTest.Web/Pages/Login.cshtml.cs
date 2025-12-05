using DesignliTest.Core.Dto.Input.UserApp;
using DesignliTest.Web.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DesignliTest.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAuthClientService _authService;

        public LoginModel(IAuthClientService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public UserLoginRequest Input { get; set; } = new();

        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            var token = await _authService.LoginAsync(Input);

            if (token == null)
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }

            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(1)
            });

            return RedirectToPage("/Users");
        }
    }
}
