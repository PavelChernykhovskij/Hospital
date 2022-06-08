namespace Hospital.Models
{
    public class Medcard
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Snils { get; set; }
        public string Medpolis { get; set; }
        public string Passport { get; set; }
        public DateTime DateOfBirth { get; set; }

        public User User { get; set; }
        public List<Request> Requests { get; set; }

    }
}
