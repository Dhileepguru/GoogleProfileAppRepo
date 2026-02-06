using Microsoft.EntityFrameworkCore;
namespace GoogleProfileApp.Models.Data
{
    public class ApplicationDbContext :DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
