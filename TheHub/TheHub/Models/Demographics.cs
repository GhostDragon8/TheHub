using System;

namespace TheHub.Models
{
    public class Demographics
    {
        public int DemID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}