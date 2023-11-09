using BLL.DTOs.ServiceDTO;
using FluentValidation;

namespace API.Validation
{
    public class ServiceValidator
    {
        public class InsertServiceValidator : AbstractValidator<InsertServiceDTO>
        {
            public InsertServiceValidator()
            {
                RuleFor(service => service.Title).NotEmpty();
            }
        }
        public class UpdateServiceValidator : AbstractValidator<UpdateServiceDTO>
        {
            public UpdateServiceValidator()
            {
                Include(new UpdateBaseValidator());

                RuleFor(service => service.Title).NotEmpty();

            }
        }
    }
}
