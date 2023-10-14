using FluentValidation;
using BLL.DTOs.ProjectDTO;


namespace API.Validation
{
    public class InsertProjectValidator : AbstractValidator<InsertProjectDTO>
    {
        public InsertProjectValidator()
        {
            RuleFor(dto => dto.Title).NotEmpty().MaximumLength(100);
            RuleFor(dto => dto.Description).NotEmpty().MaximumLength(1000);
            RuleFor(dto => dto.Period).NotEmpty().MaximumLength(50);
            RuleFor(dto => dto.DateYear).NotEmpty().InclusiveBetween(2000, DateTime.Now.Year);
            RuleFor(dto => dto.RequestDescription).NotEmpty().MaximumLength(500);
            RuleFor(dto => dto.RequestList).NotEmpty();
            RuleFor(dto => dto.SolutionDescription).NotEmpty().MaximumLength(500);
            RuleForEach(dto => dto.Pictures).NotNull();
            RuleForEach(dto => dto.Paragraphs).NotNull();
            RuleForEach(dto => dto.Technologies).NotNull();
            RuleFor(dto => dto.Country).NotNull();
        }
    }

    public class UpdateProjectValidator : AbstractValidator<UpdateProjectDTO>
    {
        public UpdateProjectValidator()
        {
            Include(new UpdateBaseValidator());

            RuleFor(dto => dto.Title).NotEmpty().MaximumLength(100);
            RuleFor(dto => dto.Description).NotEmpty().MaximumLength(1000);
            RuleFor(dto => dto.Period).NotEmpty().MaximumLength(50);
            RuleFor(dto => dto.DateYear).NotEmpty().InclusiveBetween(2000, DateTime.Now.Year);
            RuleFor(dto => dto.RequestDescription).NotEmpty().MaximumLength(500);
            RuleFor(dto => dto.RequestList).NotEmpty();
            RuleFor(dto => dto.SolutionDescription).NotEmpty().MaximumLength(500);
            RuleForEach(dto => dto.Pictures).NotNull();
            RuleForEach(dto => dto.Paragraphs).NotNull();
            RuleForEach(dto => dto.Technologies).NotNull();
            RuleFor(dto => dto.Country).NotNull();
        }
    }
}