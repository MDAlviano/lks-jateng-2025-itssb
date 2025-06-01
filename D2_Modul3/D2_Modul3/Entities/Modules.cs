using System.ComponentModel.DataAnnotations.Schema;

namespace D2_Modul3.Entities
{
    [Table("Modules")]
    public class Modules
    {
        public int id { get; set; }
        public int course_id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
    }
}
