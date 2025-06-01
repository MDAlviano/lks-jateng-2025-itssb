namespace D2_Modul3.Entities
{
    public class Purchases
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int course_id { get; set; }
        public int coupon_id { get; set; }
        public double price_paid { get; set; }
        public string payment_method { get; set; }
        public DateTime purchased_at { get; set; }
    }
}
