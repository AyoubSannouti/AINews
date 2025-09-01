using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Articles.Queries.GetArticlesList
{
    public class GetArticlesListQuery : IRequest<List<GetArticlesListViewModel>>
    {

    }
}
