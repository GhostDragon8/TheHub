using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TheHub.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string HeroName { get; set; }
        public string UserName { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime LastLogin { get; set; }
        
        public int ProfileID { get; set; }
        public virtual Profile Profile { get; set; }
    }
    public class MemberDbContext : DbContext
    {
        public DbSet<Member> Member { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
         { 
             base.OnModelCreating(modelBuilder); 
             modelBuilder.Entity<Member>() 
                 .HasOptional<Profile>(m => m.Profile) 
                 .WithRequired(m => m.Member)
                 .Map(p => p.MapKey("MemberID")); 
         }

        public System.Data.Entity.DbSet<TheHub.Models.Profile> Profiles { get; set; }
    }
}