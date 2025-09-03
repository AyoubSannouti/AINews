using AINews.Application.Contracts;
using AINews.Application.Features.Articles.Commands.UpdateArticle;
using AINews.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.ArticleCategories.Commands.Update_ArticleCategory
{
    internal class UpdateArticleCategoryCommandHandler : IRequestHandler<UpdateArticleCategoryCommand>
    {
        private readonly IAsyncRepository<ArticleCategory> _articleCategoryRepository;
        private readonly IMapper _mapper;
        public UpdateArticleCategoryCommandHandler(IAsyncRepository<ArticleCategory> articleCategoryRepository, IMapper mapper)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateArticleCategoryCommand request, CancellationToken cancellationToken)
        {
            ArticleCategory articleCategory = _mapper.Map<ArticleCategory>(request);
            await _articleCategoryRepository.UpdateAsync(articleCategory);
            return Unit.Value;
        }
    }
}
