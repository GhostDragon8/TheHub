namespace TheHub.Models
{
    public class Profile
    {
        public int ProfID { get; set; }
        public string Bio { get; set; }

        public int DemID { get; set; }
        public virtual Demographics Demographics { get; set; }

        public int InterestID { get; set; }
        public virtual Interest Interest { get; set; }

        public int PhotoID {get;set;}
        public virtual Photos Photos { get; set; }

    }
}