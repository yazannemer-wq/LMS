using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Security;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using ArkkanLMS.Web.Authorization;
using ArkkanLMS.Web.Localization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public LocaleProvider Locale { get; }

        public RegisterModel(AppDbContext dbContext, LocaleProvider locale)
        {
            _dbContext = dbContext;
            Locale = locale;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            [Required]
            [StringLength(80, MinimumLength = 2)]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [MinLength(6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return Page();

            var email = (Input.Email ?? string.Empty).Trim();
            var name = (Input.Name ?? string.Empty).Trim();

            var exists = await _dbContext.Users.AnyAsync(u => u.Email == email);
            if (exists)
            {
                ModelState.AddModelError(string.Empty, Locale.IsRtl ? "هذا البريد مستخدم بالفعل." : "That email is already registered.");
                return Page();
            }

            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = HashPassword(Input.Password),
                Role = UserRoleType.Trainee
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Name),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.Email),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, user.Role.ToString()),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            foreach (var perm in RolePermissions.Get(user.Role))
            {
                claims.Add(new System.Security.Claims.Claim(Permissions.ClaimType, perm.ToString()));
            }

            var identity = new System.Security.Claims.ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new System.Security.Claims.ClaimsPrincipal(identity));

            var localReturnUrl = string.IsNullOrWhiteSpace(returnUrl) ? Url.Content("~/Dashboard/Index") : returnUrl;
            if (!Url.IsLocalUrl(localReturnUrl))
                localReturnUrl = Url.Content("~/Dashboard/Index");

            return LocalRedirect(localReturnUrl);
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password ?? string.Empty);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}

