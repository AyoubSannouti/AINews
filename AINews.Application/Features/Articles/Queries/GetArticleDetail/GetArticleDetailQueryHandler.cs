using AINews.Application.Contracts;
using MediatR;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Articles.Queries.GetArticleDetail
{
    internal class GetArticleDetailQueryHandler : IRequestHandler<GetArticleDetailQuery, GetArticleDetailViewModel>
    {
        public readonly IArticleRepository _articleRepository;
        public readonly IMapper _mapper;

        public GetArticleDetailQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<GetArticleDetailViewModel> Handle(GetArticleDetailQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetArticleByIdAsync(request.ArticleId, true);
            return _mapper.Map<GetArticleDetailViewModel>(article);
        }
    }
}
