using ArkkanLMS.Persistence;
using ArkkanLMS.Web.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ForgotPasswordModel> _logger;

        public LocaleProvider Locale { get; }

        public ForgotPasswordModel(AppDbContext dbContext, ILogger<ForgotPasswordModel> logger, LocaleProvider locale)
        {
            _dbContext = dbContext;
            _logger = logger;
            Locale = locale;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string SuccessMessage { get; private set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var normalized = (Input.Email ?? string.Empty).Trim();

            // Always respond with a generic success message.
            var exists = await _dbContext.Users.AsNoTracking().AnyAsync(u => u.Email == normalized);
            _logger.LogInformation("ForgotPassword requested for email={Email}, exists={Exists}", normalized, exists);

            SuccessMessage = Locale.IsRtl
                ? "إذا كان هذا البريد مسجّلًا لدينا، فستصلك رسالة تحتوي على التعليمات."
                : "If that email is registered, you’ll receive a message with reset instructions.";

            ModelState.Clear();
            Input = new InputModel();
            return Page();
        }
    }
}

