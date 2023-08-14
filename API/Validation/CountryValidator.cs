using BLL.DTOs.CountryDTO;
using FluentValidation;

namespace API.Validation
{
    public class InsertCountryValidator : AbstractValidator<InsertCountryDTO>
    {
        public InsertCountryValidator()
        {
            RuleFor(country => country.Name).NotEmpty().Matches(@"^[A-Za-z\-]+$");
        }
    }
    public class UpdateCountryValidator : AbstractValidator<UpdateCountryDTO>
    {
        public UpdateCountryValidator()
        {
            Include(new UpdateBaseValidator());

            RuleFor(country => country.Name).NotEmpty().Matches(@"^[A-Za-z\-]+$");
        }
    }
}
