using System;
using System.Data.Entity;

namespace TheHub.Models
{
    public class Photos
    {
        public int PhotoID { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        
        public DateTime DateAdded { get; set; }
        public bool ProfilePic { get; set; }

    }
    public class PhotosDbContext : DbContext
    {
        public DbSet<Photos> Photos { get; set; }
    }
}