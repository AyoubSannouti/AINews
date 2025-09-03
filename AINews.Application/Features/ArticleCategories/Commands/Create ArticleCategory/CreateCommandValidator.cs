using AINews.Application.Features.Articles.Commands.CreateArticle;
using FluentValidation;

namespace AINews.Application.Features.ArticleCategories.Commands.Create_ArticleCategory
{
    internal class CreateCommandValidator : AbstractValidator<CreateArticleCategoryCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required.")
                .MaximumLength(80).WithMessage("Name must not exceed 80 characters.");
        }
    }
}
