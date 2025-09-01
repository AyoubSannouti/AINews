using AINews.Application.Contracts;
using AINews.Application.Features.Articles.Commands.CreateArticle;
using AINews.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Events.Commands.CreateEvent
{
    internal class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            Event eventobj = _mapper.Map<Event>(request);
            CreateCommandValidator Validator = new CreateCommandValidator();
            var validationResult = await Validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new Exception("Event is not valid");
            }

            eventobj = await _eventRepository.AddAsync(eventobj);

            return eventobj.Id;
        }
    }
}
