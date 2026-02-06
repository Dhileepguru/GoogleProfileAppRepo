using GoogleProfileApp.Models;
using GoogleProfileApp.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GoogleProfileApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Profile()
        {
            var googleId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Fetch that user from your DB
            var user = await dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.GoogleId == googleId);

            if (user == null) return NotFound();

            return View(user);
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(ApplicationUser updatedUser)
        {
            
            var userInDb = await dbContext.ApplicationUsers.FindAsync(updatedUser.Id);

            if (userInDb != null)
            {
                
                userInDb.FirstName = updatedUser.FirstName;
                userInDb.LastName = updatedUser.LastName;

                await dbContext.SaveChangesAsync();
                return RedirectToAction("Welcome", "Home");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
