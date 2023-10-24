using BLL.DTOs.PeriodProgressDTO;
using FluentValidation;

namespace API.Validation
{
    public class InsertPeriodProgressValidator : AbstractValidator<InsertPeriodProgressDTO>
    {
        public InsertPeriodProgressValidator()
        {
            RuleFor(dto => dto.NumberWeek).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("NumberWeek must have whole digit!");
            RuleFor(dto => dto.Development).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100).WithMessage("Development must have whole digit!");
            RuleFor(dto => dto.Security).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100).WithMessage("Security must have whole digit!");
            RuleFor(dto => dto.Designer).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100).WithMessage("Designer must have whole digit!");
            RuleFor(dto => dto.OrderProjectStatusId).NotNull();
        }
    }

    public class UpdatePeriodProgressValidator : AbstractValidator<UpdatePeriodProgressDTO>
    {
        public UpdatePeriodProgressValidator()
        {
            Include(new UpdateBaseValidator());

            RuleFor(dto => dto.NumberWeek).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("NumberWeek must have whole digit!");
            RuleFor(dto => dto.Development).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100).WithMessage("Development must have whole digit!");
            RuleFor(dto => dto.Security).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100).WithMessage("Security must have whole digit!");
            RuleFor(dto => dto.Designer).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100).WithMessage("Designer must have whole digit!");
            RuleFor(dto => dto.OrderProjectStatusId).NotNull();
        }
    }
}
