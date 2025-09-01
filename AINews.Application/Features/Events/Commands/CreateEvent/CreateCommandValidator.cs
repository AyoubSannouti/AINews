using AINews.Application.Features.Articles.Commands.CreateArticle;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Events.Commands.CreateEvent
{
    internal class CreateCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateCommandValidator() 
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(c => c.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Description is required.");

            RuleFor(c => c.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl is required.")
                .MaximumLength(500).WithMessage("ImageUrl must not exceed 500 characters.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("ImageUrl must be a valid URL.");

            RuleFor(c => c.EventDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("PublishedDate is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("PublishedDate cannot be in the future.");


            RuleFor(c => c.CategoryId)
                .NotEmpty().WithMessage("CategoryId is required).");
        }
    }
}
