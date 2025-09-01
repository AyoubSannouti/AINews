using AINews.Application.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Articles.Commands.DeleteArticle
{
    internal class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;

        public DeleteArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;

        }
        public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetByIdAsync(request.ArticleId);

            if (article == null)
            {
                throw new Exception("Article not found");
            }
            await _articleRepository.DeleteAsync(article);
            return Unit.Value;
        }
    }
}
