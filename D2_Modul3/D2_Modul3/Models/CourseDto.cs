namespace D2_Modul3.Models
{
    public class CourseDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int duration { get; set; }
        public List<string> modules { get; set; }
    }
}
