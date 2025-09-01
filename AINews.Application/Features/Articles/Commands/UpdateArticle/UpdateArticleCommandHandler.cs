using AINews.Application.Contracts;
using AINews.Domain.Entities;
using AutoMapper;
using MediatR;
using System;


namespace AINews.Application.Features.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
    {
        private readonly IAsyncRepository<Article> _articleRepository;
        private readonly IMapper _mapper;
        public UpdateArticleCommandHandler(IAsyncRepository<Article> articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            Article article = _mapper.Map<Article>(request);
            await _articleRepository.UpdateAsync(article);
            return Unit.Value;

        }
    }
}
