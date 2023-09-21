using BLL.DTOs.BlogDTO;
using FluentValidation;

namespace API.Validation
{
    public class InsertBlogValidator : AbstractValidator<InsertBlogDTO>
    {
        public InsertBlogValidator()
        {
            RuleFor(dto => dto.SVG).NotNull();
            RuleFor(dto => dto.Paragraphs).NotNull();
            RuleFor(dto => dto.Pictures).NotNull();
            RuleFor(dto => dto.AuthorId).NotEmpty();
            RuleFor(dto => dto.Title).NotEmpty();
            RuleFor(dto => dto.Description).NotEmpty();
            RuleFor(dto => dto.Viewers).GreaterThanOrEqualTo(0);
        }
    }
    public class UpdateBlogValidator : AbstractValidator<UpdateBlogDTO>
    {
        public UpdateBlogValidator()
        {
            Include(new UpdateBaseValidator());

            RuleFor(dto => dto.SVG).NotNull();
            RuleFor(dto => dto.Pictures).NotNull();
            RuleFor(dto => dto.Paragraphs).NotNull();
            RuleFor(dto => dto.AuthorId).NotEmpty();
            RuleFor(dto => dto.Title).NotEmpty();
            RuleFor(dto => dto.Description).NotEmpty();
            RuleFor(dto => dto.Viewers).GreaterThanOrEqualTo(0);
        }
    }

}
