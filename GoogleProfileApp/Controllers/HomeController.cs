using GoogleProfileApp.Models;
using GoogleProfileApp.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace GoogleProfileApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult ApplicationUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Welcome");
            }
            return View();
        }

        
        [Authorize] // 
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> Welcome()
        {
            // Get the GoogleId from the logged-in user's claims
            var googleId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Fetch user details directly from DB (Requirement 5)
            var user = await dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.GoogleId == googleId);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }
}
