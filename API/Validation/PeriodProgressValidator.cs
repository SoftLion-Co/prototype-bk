using BLL.DTOs.PeriodProgressDTO;
using FluentValidation;

namespace API.Validation
{
    public class InsertPeriodProgressValidator : AbstractValidator<InsertPeriodProgressDTO>
    {
        public InsertPeriodProgressValidator()
        {
            RuleFor(dto => dto.NumberWeek).GreaterThanOrEqualTo(0).WithMessage("NumberWeek must have whole digit!");
            RuleFor(dto => dto.OrderProjectStatusId).NotNull();
            RuleFor(dto => dto.Progress).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100).WithMessage("Progress is between 0 and 100");
        }
    }

    public class UpdatePeriodProgressValidator : AbstractValidator<UpdatePeriodProgressDTO>
    {
        public UpdatePeriodProgressValidator()
        {
            Include(new UpdateBaseValidator());

            RuleFor(dto => dto.NumberWeek).GreaterThanOrEqualTo(0).WithMessage("NumberWeek must have whole digit!");
            RuleFor(dto => dto.OrderProjectStatusId).NotNull();
            RuleFor(dto => dto.Progress).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100).WithMessage("Progress is between 0 and 100");

        }
    }
}
