using System.ComponentModel.DataAnnotations.Schema;

namespace D2_Modul3.Entities
{
    [Table("Coupons")]
    public class Coupons
    {
        public int id { get; set; }
        public string code { get; set; }
        public decimal discount_pct { get; set; }
        public int quota { get; set; }
        public DateTime expiry_date { get; set; }
        public DateTime created_at { get; set; }
    }
}
