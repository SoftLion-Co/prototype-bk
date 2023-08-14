using BLL.DTOs.TechnologyDTO;
using FluentValidation;

namespace API.Validation
{
    public class InsertTechnologyValidator : AbstractValidator<InsertTechnologyDTO>
    {
        public InsertTechnologyValidator()
        {
            RuleFor(ctechnology => ctechnology.Name).NotEmpty().Matches(@"^[A-Za-z\-]+$");
        }
    }
    public class UpdateTechnologyValidator : AbstractValidator<UpdateTechnologyDTO>
    {
        public UpdateTechnologyValidator()
        {
            Include(new UpdateBaseValidator());

            RuleFor(ctechnology => ctechnology.Name).NotEmpty().Matches(@"^[A-Za-z\-]+$");
        }
    }
}
