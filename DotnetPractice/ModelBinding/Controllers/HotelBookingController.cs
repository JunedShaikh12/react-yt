using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;
using ModelBinding.Repository.Services;

namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class HotelBookingController : ControllerBase
    {

        private readonly ILogger<HotelBookingController> _logger;
        private readonly IBookingDetailService _bookingDetailService;
        private readonly IMapper _mapper;
        private readonly IValidator<BookingDetails> _validator;
        private readonly IValidator<CreateRoomBook> _createRoomValidator;

        public HotelBookingController(IBookingDetailService bookingDetailService , IMapper mapper , ILogger<HotelBookingController> logger , IValidator<BookingDetails> validator , IValidator<CreateRoomBook> createRoomValidator) {
            _bookingDetailService = bookingDetailService;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
            _createRoomValidator = createRoomValidator;
        }

        [HttpGet("BookedRecord")] 
        public IActionResult getBookedRecord ()
        {
            var bookedData = _bookingDetailService.AllBookedRecord();
            _logger.LogInformation("Juned Learning Serilog");
            var bookedContainDTOdata = _mapper.Map<List<BookingdetailsDTO >> (bookedData);
            return Ok(bookedContainDTOdata);
        }


        [HttpPost("{HotelId}/book")]
        public IActionResult BookHotelRoom(
            [FromRoute]int HotelId,
            [FromQuery] DateTime checkIn,
            [FromQuery] DateTime checkOut,
            [FromHeader(Name = "Authorization")] string roleToken,
            [FromBody] BookingDetails details
            )
        {

            if (string.IsNullOrEmpty(roleToken))
            {
                return Unauthorized("USER TOKEN IS NOT FOUND!!!");
            }
            var result = _validator.Validate(details);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                var confirmHotel = _bookingDetailService.BookRoom(HotelId, checkIn, checkOut, roleToken, details);
                return Ok(confirmHotel);
            }
        }


        [HttpGet("transaction/{transactionType}")]
        public IActionResult TransactionDetails (string transactionType)
        {
            var paidRoomData = _bookingDetailService.paidRoomBook(transactionType);
            var mappedData = _mapper.Map<List<OnlineBookDTO>>(paidRoomData);
            var Data = _bookingDetailService.symbolCode(mappedData);
            return Ok(Data);
        }

        [HttpPost("AddTransaction")]

        public IActionResult newCustomertransactions([FromBody] CreateRoomBook createRoomBook)
        {


            var result = _createRoomValidator.Validate(createRoomBook);
            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                _bookingDetailService.newCustomerTransaction(createRoomBook);
                var allusers = _bookingDetailService.allTransactionRecord();
                return Ok(allusers);
            }
        }


        [HttpPut("ChnagePaymentMode")]

        public IActionResult changePaymentMode (int Id ,[FromBody] OnlineBook onlineBook)
        {
             _bookingDetailService.changePay(Id, onlineBook);
            var allusers = _bookingDetailService.allTransactionRecord();

            return Ok(allusers);
        }

        [HttpPut("changeData")]
        public IActionResult updateUser (int id ,[FromBody] User user)
        {
            var updatedUser = _bookingDetailService.updateUserData(id , user);
            return Ok(updatedUser);
        }

        [HttpGet("mapperly")]
        public IActionResult getAllDAta ()
        {
            var getData = _bookingDetailService.getAllInfo();
            return Ok(getData);
        }


        [HttpPut("update")]

        public IActionResult updateName(User user)
        {
            var updatedData = _bookingDetailService.updateNameValue(user);
            return Ok(updatedData);
        }


        [HttpGet]
        public IActionResult CreateOrder()
        {
            _logger.LogInformation(
                "Order Created Successfully");

            return Ok();
        }
    }
}
