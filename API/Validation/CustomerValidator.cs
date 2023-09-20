using FluentValidation;
using BLL.DTOs.CustomerDTO;

namespace API.Validation
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerValidator()
        {
            Include(new UpdateBaseValidator());
            RuleFor(dto => dto.Email).NotEmpty().EmailAddress();
            RuleFor(dto => dto.PhoneNumber).NotEmpty();
            RuleFor(dto => dto.FirstName).MaximumLength(50);
            RuleFor(dto => dto.LastName).MaximumLength(50);
           
        }
    }
}
