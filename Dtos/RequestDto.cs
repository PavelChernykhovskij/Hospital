namespace Hospital.Dtos
{
    public class RequestDto
    {
        public DateTime DateOfVisit { get; set; }
        public string Comment { get; set; }
        public Status Status { get; set; }

    }
}
