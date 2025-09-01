using System;
using MediatR;
using AINews.Domain.Entities;
using AINews.Application.Contracts;
using AutoMapper;

namespace AINews.Application.Features.Articles.Commands.CreateArticle
{
    internal class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Guid>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public CreateArticleCommandHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            Article article = _mapper.Map<Article>(request);
            CreateCommandValidator Validator = new CreateCommandValidator();
            var validationResult = await Validator.ValidateAsync(request);

            if(validationResult.Errors.Any())
            {
                throw new Exception("Article is not valid");
            }

            article = await _articleRepository.AddAsync(article);

            return article.Id;
        }
    }
}
