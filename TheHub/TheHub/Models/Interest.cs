using System.Data.Entity;

namespace TheHub.Models
{
    public class Interest
    {
        public int InterestID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
    public class InterestDbContext : DbContext
    {
        public DbSet<Interest> Interest { get; set; }
    }
}