using ArkkanLMS.Web.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArkkanLMS.Web.Pages
{
    public class StatusModel : PageModel
    {
        public int Code { get; private set; }
        public string Title { get; private set; }
        public string Message { get; private set; }
        public string Icon { get; private set; }

        public LocaleProvider Locale { get; }

        public StatusModel(LocaleProvider locale)
        {
            Locale = locale;
        }

        public IActionResult OnGet(int code)
        {
            Code = code;
            var isAr = Locale?.IsRtl ?? false;

            switch (code)
            {
                case 401:
                    Title = isAr ? "يلزم تسجيل الدخول" : "Sign in required";
                    Message = isAr ? "الرجاء تسجيل الدخول للمتابعة." : "Please sign in to continue.";
                    Icon = "bi-shield-lock";
                    break;
                case 403:
                    Title = isAr ? "غير مصرح" : "Not allowed";
                    Message = isAr ? "ليس لديك صلاحية للوصول إلى هذه الصفحة." : "You don’t have permission to access this page.";
                    Icon = "bi-shield-exclamation";
                    break;
                case 404:
                    Title = isAr ? "الصفحة غير موجودة" : "Page not found";
                    Message = isAr ? "لم نتمكن من العثور على الصفحة المطلوبة." : "We couldn’t find the page you’re looking for.";
                    Icon = "bi-compass";
                    break;
                default:
                    Title = isAr ? "حدث خطأ" : "Something went wrong";
                    Message = isAr ? "حدثت مشكلة غير متوقعة. حاول مرة أخرى." : "An unexpected issue occurred. Please try again.";
                    Icon = "bi-exclamation-triangle";
                    break;
            }

            // If someone navigates directly to /Status/500, route to the canonical error page.
            if (code >= 500)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}

