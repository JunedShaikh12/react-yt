namespace ModelBinding.Models
{
    public class BookingdetailsDTO
    {
        public string GuestKaName { get; set; }
        public string RoomKaType { get; set; }
        public int GuestsNumber { get; set; }
        public bool IncludedBreakfast { get; set; }
        public string TransactionType { get; set; }
        public RoomOrderDTO roomOrder { get; set; }

    }
}
