namespace Hospital.Dtos
{
    public class QuestionnaireDto
    {
        public string DoctorsName { get; set; }
        public string DoctorsSpec { get; set; }

        public List<QuestionDto> Questions { get; set; }
    }
}
