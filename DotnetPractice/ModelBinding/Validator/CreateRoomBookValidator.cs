using FluentValidation;
using ModelBinding.Models;

namespace ModelBinding.Validator
{
    public class CreateRoomBookValidator : AbstractValidator<CreateRoomBook>
    {
        public CreateRoomBookValidator()
        {
            RuleFor(x => x.UPI)
                .NotEmpty().When(c => c.postPaid == true).WithMessage("PostPaid must be false...");

            RuleFor(x => x.cash)
                .Length(5).WithMessage("Iski length 5 kr bhaii...")
                .Must(c => c.All(char.IsLetter)).WithMessage("Ye letter nhi hai bhaiii...");
                
        }
    }
}
