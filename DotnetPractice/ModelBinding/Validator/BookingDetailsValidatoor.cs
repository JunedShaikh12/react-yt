using ModelBinding.Models;
using FluentValidation;
namespace ModelBinding.Validator
{
    public class BookingDetailsValidatoor : AbstractValidator<BookingDetails>
    {
        public BookingDetailsValidatoor ()
        {
            RuleFor(b => b.GuestName).NotEmpty().WithMessage("GuestName iiiiis Required.");
            //RuleFor(b => b.);
        }
    }
}
