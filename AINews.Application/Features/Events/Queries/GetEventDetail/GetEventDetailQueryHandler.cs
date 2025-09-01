using AINews.Application.Contracts;
using AINews.Application.Features.Articles.Queries.GetArticleDetail;
using AutoMapper;
using MediatR;


namespace AINews.Application.Features.Events.Queries.GetEventDetail
{
    internal class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, GetEventDetailViewModel>
    {
        public readonly IEventRepository _eventRepository;
        public readonly IMapper _mapper;

        public GetEventDetailQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<GetEventDetailViewModel> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var eventobj = await _eventRepository.GetEventByIdAsync(request.EventId, true);
            return _mapper.Map<GetEventDetailViewModel>(eventobj);
        }
    }
}
