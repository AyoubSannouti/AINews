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

namespace AINews.Application.Features.Events.Commands.UpdateEvent
{
    internal class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        public UpdateEventCommandHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            Event eventobj = _mapper.Map<Event>(request);
            await _eventRepository.UpdateAsync(eventobj);
            return Unit.Value;

        }
    }
}
