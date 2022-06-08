namespace Hospital.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int MedcardId { get; set; }

        public DateTime DateOfVisit { get; set; }
        public string Comment { get; set; }
        public Status Status { get; set; }

        public Doctor Doctor { get; set; }
        public Medcard Medcard { get; set; }

    }
}
