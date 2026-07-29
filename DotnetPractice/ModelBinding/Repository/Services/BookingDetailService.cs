using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.HardCode_Data;
using ModelBinding.Mapperly;
using ModelBinding.Models;

namespace ModelBinding.Repository.Services
{
    public class BookingDetailService : IBookingDetailService
    {

        public readonly IMapper _mapper;

        public BookingDetailService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public string transactionTypeCash = hardCodeValues.transactionTypeCash;
        public string transactionTypeUpi = hardCodeValues.transactionTypeUpi;
        public string transactionTypeCard = hardCodeValues.transactionTypeCard;
        public string couponCode = hardCodeValues.couponCode;
        public string[] allTransactions = hardCodeValues.transactions;
        public static List<BookingDetails> HotelRoomBookedData = new List<BookingDetails> {
            new BookingDetails { GuestName = "Juned" , RoomType = "AC", GuestsNumber = 12 , IncludedBreakfast = true ,TransactionType = "Cash",roomOrder =new  RoomOrder { roomClean = true, liked = true } },
            new BookingDetails { GuestName = "Shaikh" , RoomType = "NON-AC", GuestsNumber = 12 , IncludedBreakfast = false , TransactionType = "Upi"},
            new BookingDetails { GuestName = "BAgru" , RoomType = "AC", GuestsNumber = 12 , IncludedBreakfast = true, TransactionType = "Card"},
            new BookingDetails { GuestName = "BOZO" , RoomType = "AC", GuestsNumber = 12 , IncludedBreakfast = true , TransactionType = "Cash"},
            new BookingDetails { GuestName = "Manu" , RoomType = "NON-AC", GuestsNumber = 12 , IncludedBreakfast = false , TransactionType = "Cash"},
            new BookingDetails { GuestName = "Chimkandi" , RoomType = "NON-AC", GuestsNumber = 12 , IncludedBreakfast = false , TransactionType = "Not paid"}
            };

        public static List<OnlineBook> transactionDetails = new List<OnlineBook> {

            new OnlineBook { Id = 1, prePaid = true , postPaid = false, Coupon  = "##**", payment = new paymentMethods { cash = "Cash" , UPI = null , Card = null}},
            new OnlineBook { Id = 2, prePaid = false , postPaid = true, Coupon  = "##@@", payment = new paymentMethods { cash = null , UPI = "Upi" , Card = null}},
            new OnlineBook { Id = 3, prePaid = true , postPaid = false, Coupon  = "#@@*", payment = new paymentMethods { cash = null , UPI = "Upi" , Card = null}},
            new OnlineBook { Id = 4, prePaid = false , postPaid = true, Coupon  = "##@*", payment = new paymentMethods { cash = "Cash" , UPI = null , Card = "Card"}},
            new OnlineBook { Id = 5, prePaid = true , postPaid = false, Coupon  = "@#**", payment = new paymentMethods { cash = null , UPI = "Upi" , Card = null}},
            new OnlineBook { Id = 6, prePaid = false , postPaid = true, Coupon  = "@@**", payment = new paymentMethods { cash = "Cash" , UPI = null , Card = null}}
    };


        public static List<User> Users = new List<User>
        {
            new User { Id = 1 , Name = "Juned" , isnearBy  = "Yes" , VisitCount = 7},
            new User { Id = 2 , Name = "Shaikh" , isnearBy  = "Yes" , VisitCount = 9},
            new User { Id = 3 , Name = "Bozo" , isnearBy  = "No" , VisitCount = 15},
            new User { Id = 4 , Name = "Bagru" , isnearBy  = null , VisitCount = 8},
            new User { Id = 5 , Name = "Manu" , isnearBy  = "No" , VisitCount = 10},
            new User { Id = 6 , Name = "Chimkandi" , isnearBy  = "No" , VisitCount = 5}
        };
        public List<BookingDetails> AllBookedRecord()
        {
            var bookedData = HotelRoomBookedData;

            return bookedData;
        }
        public IActionResult BookRoom(int HotelId, DateTime checkIn, DateTime checkOut, string roleToken, BookingDetails details)
        {

            var confirm = new
            {
                HotelId = HotelId,
                checkIn,
                checkOut,
                roleToken = roleToken,
                details.GuestName,
                details.GuestsNumber,
                details.IncludedBreakfast,
                details.RoomType
            };
            return new JsonResult(confirm)
            {
                ContentType = "application/json"
            };
        }

        public List<OnlineBook> paidRoomBook(string transactionType)
        {
            if (transactionType != null && transactionType == transactionTypeCash)
            {
                var paidRoomBookData = transactionDetails.FindAll(p => p.payment.cash == transactionType);
                return paidRoomBookData;
            }
            else
            {
                return null;
            }
        }

        public List<OnlineBookDTO> symbolCode(List<OnlineBookDTO> mappedData)
        {
            var Data = mappedData.Where(p => p.Coupon == couponCode).ToList();
            return Data;
        }

        public OnlineBook newCustomerTransaction(CreateRoomBook createRoomBook)
        {
            OnlineBook newCustTrans = _mapper.Map<OnlineBook>(createRoomBook);
            transactionDetails.Add(newCustTrans);
            return newCustTrans;
        }

        public List<OnlineBookDTO> allTransactionRecord()
        {
            var allTransactions = transactionDetails;
            //var newOnePlus = _mapper.Map<OnlineBookDTO>(allTransactions);
            var AlltransRecord = _mapper.Map<List<OnlineBookDTO>>(allTransactions);
            return AlltransRecord;
        }

        public OnlineBook changePay(int Id, OnlineBook onlineBook)
        {
            var allTransactions = transactionDetails?.Find(P => P.Id == Id);
            _mapper.Map(onlineBook, allTransactions);
            return allTransactions;
        }

            public List<UserDTO> updateUserData(int id, User user)
            {
                var updatedRecord = Users.FirstOrDefault(p => p.Id == id);
            Console.WriteLine(updatedRecord.Name);
                var updateUser = _mapper.Map(user, updatedRecord);
                var allUsers = Users;
                var dto = _mapper.Map<List<UserDTO>>(allUsers);
                return dto;
            }

        //public List<UserDTO> getAllUsers(UserDTO updatedUser)
        //{
        //    var users = Users.Where(p =>)

        //    var allusers = _mapper.Map<List<UserDTO>>(users);
        //    return allusers;
        //}


        //public UserDTO getDatamapper ()
        //{
        //    var users = Users;
        //    var mapper = new UserMapper();

        //    var getAllData = mapper.ToDto(users);
        //    return getAllData;
        //}

        public List<UserDTO> getAllInfo ()
        {
            var users = Users;
            var mapper = new UserMapper();
            var getData = mapper.getDTOData(users);
            return getData;
        }



        public UserDTO updateNameValue (User user)
        {
            var selectedrecord = Users.FirstOrDefault(p => p.Id == user.Id);
            var mapper = new UserMapper();
            var mapping = mapper.updateUserToUserDTO(user , selectedrecord);
            return mapping;
        }
    }
}

