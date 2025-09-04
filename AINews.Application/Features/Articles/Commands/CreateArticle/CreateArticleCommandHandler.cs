using System;
using MediatR;
using AINews.Domain.Entities;
using AINews.Application.Contracts;
using AutoMapper;

namespace AINews.Application.Features.Articles.Commands.CreateArticle
{
    internal class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Guid>
    {
        private readonly IIdentityService _identityService;
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public CreateArticleCommandHandler(IArticleRepository articleRepository, IMapper mapper, IIdentityService identityService)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _identityService = identityService;
        }
        public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            // ✅ get current logged-in user from token
            var me = await _identityService.GetCurrentUserAsync();
            if (me == null)
                throw new UnauthorizedAccessException("User not logged in");

            var article = new Article
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Content = request.Content,
                ImageUrl = request.ImageUrl,
                CategoryId = request.CategoryId,
                AuthorId = me.Id,
                PublishedDate = DateTime.UtcNow
            };

            await _articleRepository.AddAsync(article);
            return article.Id;
        }
    }
}
