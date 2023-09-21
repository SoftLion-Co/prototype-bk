using BLL.DTOs.RatingDTO;
using FluentValidation;

namespace API.Validation
{
    public class InsertRatingValidator : AbstractValidator<InsertRatingDTO>
    {
        public InsertRatingValidator()
        {
            RuleFor(dto => dto.Mark).InclusiveBetween(1, 5);
            RuleFor(dto => dto.ProjectId).NotEmpty();
        }
    }
    public class UpdateRatingValidator : AbstractValidator<UpdateRatingDTO>
    {
        public UpdateRatingValidator()
        {
            Include(new UpdateBaseValidator());

            RuleFor(dto => dto.Mark).InclusiveBetween(1, 5);
            RuleFor(dto => dto.ProjectId).NotEmpty();
        }
    }
}
