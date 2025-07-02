namespace D2_Modul3.Models
{
    public class CreateCourseDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int duration { get; set; }
        public List<string> modules { get; set; }
    }
}
