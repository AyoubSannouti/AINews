using AINews.Application.Features.ArticleCategories.Commands.Create_ArticleCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.EventCategories.Commands.CreateEventCategory
{
    internal class CreateCommandValidator : AbstractValidator<CreateEventCategoryCommand>
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
