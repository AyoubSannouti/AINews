using AINews.Application.Contracts;
using AINews.Application.Features.Articles.Queries.GetArticlesList;
using AINews.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.ArticleCategories.Queries.GetArticleCategoriesList
{
    internal class GetArticleCategoriesListQueryHandler : IRequestHandler<GetArticleCategoriesListQuery, List<ArticleCategory>>
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IMapper _mapper;

        public GetArticleCategoriesListQueryHandler(IArticleCategoryRepository articleCategoryRepository, IMapper mapper)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ArticleCategory>> Handle(GetArticleCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allArticleCategories = await _articleCategoryRepository.GetAllArticleCategoriesAsync();
            return _mapper.Map<List<ArticleCategory>>(allArticleCategories);
        }
    }
}
