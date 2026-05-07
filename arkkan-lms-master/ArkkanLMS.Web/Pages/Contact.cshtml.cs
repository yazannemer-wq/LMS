using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArkkanLMS.Web.Pages
{
    public class ContactModel : PageModel
    {
        [TempData]
        public string StatusMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string name, string email, string message)
        {
            StatusMessage = "Message received (demo).";
            return RedirectToPage();
        }
    }
}

