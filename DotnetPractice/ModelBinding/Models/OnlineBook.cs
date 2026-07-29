namespace ModelBinding.Models
{
    public class OnlineBook
    {
        public int Id { get; set; }
        public bool prePaid {  get; set; }
        public bool postPaid { get; set; }
        
        public string Coupon { get; set; }

        public paymentMethods payment { get; set; }
    }
}
