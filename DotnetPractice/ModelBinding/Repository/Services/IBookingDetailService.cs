using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Repository.Services
{
    public interface IBookingDetailService
    {
         List<BookingDetails> AllBookedRecord();
        IActionResult BookRoom(int HotelId, DateTime checkIn, DateTime checkOut , string roleToken, BookingDetails details);

        List<OnlineBook> paidRoomBook(string transactionType);

        List<OnlineBookDTO> symbolCode(List<OnlineBookDTO> mappedData);
        OnlineBook newCustomerTransaction(CreateRoomBook createRoomBook);

        List<OnlineBookDTO> allTransactionRecord();

       OnlineBook changePay(int Id , OnlineBook onlineBookDTO);

        List<UserDTO> updateUserData(int id, User user);
        //List<UserDTO> getAllUsers(UserDTO updatedUser);

        List<UserDTO> getAllInfo();

        UserDTO updateNameValue(User user);
    }
}
