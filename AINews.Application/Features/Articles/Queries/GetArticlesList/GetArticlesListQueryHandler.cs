using AINews.Application.Contracts;
using AutoMapper;
using MediatR;

namespace AINews.Application.Features.Articles.Queries.GetArticlesList
{
    internal class GetArticlesListQueryHandler : IRequestHandler<GetArticlesListQuery, List<GetArticlesListViewModel>>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        
        public GetArticlesListQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<List<GetArticlesListViewModel>> Handle(GetArticlesListQuery request, CancellationToken cancellationToken)
        {
            var allArticles = await _articleRepository.GetAllArticlesAsync(true);
            return _mapper.Map<List<GetArticlesListViewModel>>(allArticles);
        }
    }
}
