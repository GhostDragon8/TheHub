using System;
using System.Collections.Generic;
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
}