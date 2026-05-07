using Microsoft.AspNetCore.Http;

namespace ArkkanLMS.Web.Localization
{
    /// <summary>
    /// Per-request localization helper. Reads the "lang" cookie (en/ar) and
    /// exposes culture, direction (ltr/rtl), translation lookup, and font helpers.
    /// </summary>
    public class LocaleProvider
    {
        private readonly IHttpContextAccessor _accessor;
        public const string CookieName = "ark_lang";
        public const string ThemeCookieName = "ark_theme";

        public LocaleProvider(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Culture
        {
            get
            {
                var ctx = _accessor.HttpContext;
                if (ctx == null) return Strings.DefaultCulture;
                var cookie = ctx.Request.Cookies[CookieName];
                if (cookie == "ar") return "ar";
                return "en";
            }
        }

        public bool IsRtl => Culture == "ar";
        public string Direction => IsRtl ? "rtl" : "ltr";
        public string FontFamily => IsRtl
            ? "'Cairo','IBM Plex Sans Arabic',Inter,system-ui,-apple-system,'Segoe UI',sans-serif"
            : "Inter,system-ui,-apple-system,BlinkMacSystemFont,'Segoe UI',sans-serif";

        public string Theme
        {
            get
            {
                var ctx = _accessor.HttpContext;
                if (ctx == null) return "light";
                var cookie = ctx.Request.Cookies[ThemeCookieName];
                if (cookie == "dark") return "dark";
                return "light";
            }
        }

        public string this[string key] => Strings.Get(key, Culture);

        public string T(string key) => Strings.Get(key, Culture);

        /// <summary>Inline alternate-language helper, used in a few places.</summary>
        public string T(string key, string culture) => Strings.Get(key, culture);
    }
}
