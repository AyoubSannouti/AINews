using AINews.Application.Features.Articles.Queries.GetArticleDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<GetEventDetailViewModel>
    {
        public Guid EventId { get; set; }
    }
}
