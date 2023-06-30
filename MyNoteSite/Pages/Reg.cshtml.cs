using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyNoteSite.Pages
{
    public class RegModel : PageModel
    {
        string Login;
        string Password;
        string Password2;

        private readonly ILogger<PrivacyModel> _logger;

        public RegModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}