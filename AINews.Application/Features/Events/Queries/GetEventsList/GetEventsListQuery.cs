using AINews.Application.Features.Articles.Queries.GetArticlesList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<List<GetEventsListViewModel>>
    {
    }
}
