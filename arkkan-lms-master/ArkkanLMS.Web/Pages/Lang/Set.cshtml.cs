using ArkkanLMS.Web.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArkkanLMS.Web.Pages.Lang
{
    public class SetModel : PageModel
    {
        public IActionResult OnGet(string culture, string? returnUrl = null)
        {
            if (culture != "ar" && culture != "en")
            {
                culture = Strings.DefaultCulture;
            }

            Response.Cookies.Append(
                LocaleProvider.CookieName,
                culture,
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
