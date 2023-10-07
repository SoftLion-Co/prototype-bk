using BLL.DTOs.OrderProjectStatusDTO;
using FluentValidation;

namespace API.Validation
{
    public class InsertOrderProjectStatusValidator : AbstractValidator<InsertOrderProjectStatusDTO>
    {
        public InsertOrderProjectStatusValidator()
        {
            RuleFor(dto => dto.Title).NotEmpty().MaximumLength(100);
            RuleFor(dto => dto.CustomerId).NotNull();
            RuleFor(dto=>dto.ProjectStatus).NotNull().GreaterThanOrEqualTo(0);
        }
    }

    public class UpdateOrderProjectStatusValidator : AbstractValidator<UpdateOrderProjectStatusDTO>
    {
        public UpdateOrderProjectStatusValidator()
        {
            Include(new UpdateBaseValidator());

            RuleFor(dto => dto.Title).NotEmpty().MaximumLength(100);
            RuleFor(dto => dto.CustomerId).NotNull();
            RuleFor(dto => dto.ProjectStatus).NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
