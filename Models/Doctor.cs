namespace Hospital.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Spec { get; set; }
        public string Room { get; set; }
        public string Address { get; set; }

        public List<Request> Requests { get; set; }
    }
}
