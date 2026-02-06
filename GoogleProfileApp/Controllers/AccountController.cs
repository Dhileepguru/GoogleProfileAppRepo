using GoogleProfileApp.Models;
using GoogleProfileApp.Models.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GoogleProfileApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public AccountController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Login()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            
            var googleId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var firstName = result.Principal.FindFirstValue(ClaimTypes.GivenName);
            var lastName = result.Principal.FindFirstValue(ClaimTypes.Surname);

            // Check if user exists in Database
            var user = await dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.GoogleId == googleId);

            if (user == null)
            {
                
                user = new ApplicationUser
                {
                    GoogleId = googleId,
                    FirstName = firstName,
                    LastName = lastName
                };
                dbContext.ApplicationUsers.Add(user);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Welcome", "Home");
        }


        public async Task<IActionResult> Logout()
        {
       
       
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

    }
}
