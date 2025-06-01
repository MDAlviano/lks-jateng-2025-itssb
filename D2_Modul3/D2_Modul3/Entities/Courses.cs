using System.ComponentModel.DataAnnotations.Schema;

namespace D2_Modul3.Entities
{
    [Table("Courses")]
    public class Courses
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int duration { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
