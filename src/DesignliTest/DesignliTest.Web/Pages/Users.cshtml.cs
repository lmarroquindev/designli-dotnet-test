using DesignliTest.Core.Dto.Output.UserApp;
using DesignliTest.Web.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DesignliTest.Web.Pages
{
    public class UsersModel : PageModel
    {
        private readonly IUserClientService _userService;

        public UsersModel(IUserClientService userService)
        {
            _userService = userService;
        }

        public List<UserOutputDto> Users { get; set; } = new();

        public async Task<IActionResult> OnGet()
        {
            var token = Request.Cookies["jwt"];

            if (string.IsNullOrEmpty(token))
                return RedirectToPage("/Login");

            var users = await _userService.GetUsersAsync(token);

            if (users == null)
            {
                return RedirectToPage("/Login");
            }

            Users = users;
            return Page();
        }
    }
}
