namespace D2_Modul3.Models
{
    public class UpdateCouponDto
    {
        public string couponCode { get; set; }
        public decimal discountValue { get; set; }
        public DateTime expiryDate { get; set; }
        public int quota { get; set; }
    }
}
