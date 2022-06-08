namespace Hospital.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }

        public List<Question> Questions { get; set; }
        public Doctor Doctor { get; set; }

    }
}
