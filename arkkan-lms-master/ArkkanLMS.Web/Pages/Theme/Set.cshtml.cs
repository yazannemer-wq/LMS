using ArkkanLMS.Web.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArkkanLMS.Web.Pages.Theme
{
    public class SetModel : PageModel
    {
        public IActionResult OnGet(string mode, string? returnUrl = null)
        {
            if (mode != "dark" && mode != "light")
            {
                mode = "light";
            }

            Response.Cookies.Append(
                LocaleProvider.ThemeCookieName,
                mode,
                new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = System.DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true,
                    HttpOnly = false,
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax
                });

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            return RedirectToPage("/Index");
        }
    }
}
