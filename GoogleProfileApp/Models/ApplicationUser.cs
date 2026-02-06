namespace GoogleProfileApp.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; } //Primary key[Identity]----> Auto increment
        public string GoogleId { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; }
    }
}
