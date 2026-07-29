namespace ModelBinding.Models
{
    public class BookingDetails
    {
        public string GuestName { get; set; }
        public string RoomType { get; set; }
        public int GuestsNumber { get; set; }
        public bool IncludedBreakfast { get; set; }

        public string TransactionType { get; set; }

        public RoomOrder roomOrder { get; set; }

    }
}
