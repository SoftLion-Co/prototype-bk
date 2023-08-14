using BLL.DTOs.AuthorDTO;
using FluentValidation;

namespace API.Validation
{
    public class InsertAuthorValidator : AbstractValidator<InsertAuthorDTO>
    {
        public InsertAuthorValidator()
        {
            RuleFor(author => author.Name).NotEmpty().Matches(@"^[A-Za-z\-]+$");

            RuleFor(author => author.Surname).NotEmpty().Matches(@"^[A-Za-z\-]+$");

            RuleFor(author => author.Employment).NotEmpty();

            RuleFor(author => author.Avatar).NotEmpty();

            RuleFor(author => author.Description).NotEmpty();
        }
    }
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorDTO>
    {
        public UpdateAuthorValidator()
        {
            Include(new UpdateBaseValidator());

            RuleFor(author => author.Name).NotEmpty().Matches(@"^[A-Za-z\-]+$");
            RuleFor(author => author.Surname).NotEmpty().Matches(@"^[A-Za-z\-]+$");
            RuleFor(author => author.Employment).NotEmpty();
            RuleFor(author => author.Avatar).NotEmpty();
            RuleFor(author => author.Description).NotEmpty();
        }
    }
    
}
