using FluentValidation;
using BLL.DTOs.OrderProjectDTO;
using API.Validation;

namespace API.Validation
{
    public class InsertOrderProjectValidator : AbstractValidator<InsertOrderProjectDTO>
    {
        public InsertOrderProjectValidator()
        {
            RuleFor(dto => dto.NumberPhone).NotEmpty().Matches(@"^\+\d+$");
            RuleFor(dto => dto.Email).NotEmpty().EmailAddress();
            RuleFor(dto => dto.ShortDescription).NotEmpty().MaximumLength(500);
        }
    }

    public class UpdateOrderProjectValidator : AbstractValidator<UpdateOrderProjectDTO>
    {
        public UpdateOrderProjectValidator()
        {
            Include(new UpdateBaseValidator());

            RuleFor(dto => dto.NumberPhone).NotEmpty().Matches(@"^\+\d+$");
            RuleFor(dto => dto.Email).NotEmpty().EmailAddress();
            RuleFor(dto => dto.ShortDescription).NotEmpty().MaximumLength(500);
        }
    }
}