using FluentValidation;
using BLL.DTOs.OrderBlogDTO;
using API.Validation;

namespace API.Validation
{
    public class InsertOrderBlogValidator : AbstractValidator<InsertOrderBlogDTO>
    {
        public InsertOrderBlogValidator()
        {
            RuleFor(dto => dto.Username).NotEmpty().MaximumLength(100);
            RuleFor(dto => dto.Email).NotEmpty().EmailAddress();
            RuleFor(dto => dto.ShortDescription).NotEmpty().MaximumLength(500);
        }
    }

    public class UpdateOrderBlogValidator : AbstractValidator<UpdateOrderBlogDTO>
    {
        public UpdateOrderBlogValidator()
        {
            Include(new UpdateBaseValidator());

            RuleFor(dto => dto.Username).NotEmpty().MaximumLength(100);
            RuleFor(dto => dto.Email).NotEmpty().EmailAddress();
            RuleFor(dto => dto.ShortDescription).NotEmpty().MaximumLength(500);
        }
    }
}