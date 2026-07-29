namespace ModelBinding.Models
{
    public class OnlineBookDTO
    {
        public int Id { get; set; }
        public bool prePaid { get; set; }
        public bool postPaid { get; set; }

        public string Coupon { get; set; }

        public string cash { get; set; }
        public string UPI { get; set; }
        public string Card { get; set; }
    }

}
