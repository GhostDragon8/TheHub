using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TheHub.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Recipient { get; set; }
        public string MessageText { get; set; }
        public DateTime DateSent { get; set; }
        public bool Read { get; set; }
        public int ThreadID { get; set; }
    }

    public class MessageDbContext : DbContext
    {
        public DbSet<Message> Message { get; set; }
    }
}