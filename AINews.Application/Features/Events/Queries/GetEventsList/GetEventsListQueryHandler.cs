using AINews.Application.Contracts;
using AINews.Application.Features.Articles.Queries.GetArticlesList;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Events.Queries.GetEventsList
{
    internal class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<GetEventsListViewModel>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventsListQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<List<GetEventsListViewModel>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var allArticles = await _eventRepository.GetAllEventsAsync(true);
            return _mapper.Map<List<GetEventsListViewModel>>(allArticles);
        }
    }
}
