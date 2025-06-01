using System.ComponentModel.DataAnnotations.Schema;

namespace D2_Modul3.Entities
{
    [Table("Users")]
    public class Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public string role { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
