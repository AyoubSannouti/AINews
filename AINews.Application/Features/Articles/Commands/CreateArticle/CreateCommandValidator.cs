using FluentValidation;

namespace AINews.Application.Features.Articles.Commands.CreateArticle
{
    internal class CreateCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateCommandValidator() 
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(c => c.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage("Content is required.");

            RuleFor(c => c.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl is required.")
                .MaximumLength(500).WithMessage("ImageUrl must not exceed 500 characters.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("ImageUrl must be a valid URL.");

            RuleFor(c => c.PublishedDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("PublishedDate is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("PublishedDate cannot be in the future.");


            RuleFor(c => c.CategoryId)
                .NotEmpty().WithMessage("CategoryId is required).");
        }
    }
}
