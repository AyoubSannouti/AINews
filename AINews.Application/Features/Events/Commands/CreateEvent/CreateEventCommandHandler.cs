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
        private readonly IIdentityService _identityService;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IIdentityService identityService)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _identityService = identityService;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            // ✅ get current logged-in user from token
            var me = await _identityService.GetCurrentUserAsync();
            if (me == null)
                throw new UnauthorizedAccessException("User not logged in");

            var eventobj = new Event
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                CategoryId = request.CategoryId,
                CreatedById = me.Id,
                EventDate = DateTime.UtcNow,
                Location = request.Location
            };

            await _eventRepository.AddAsync(eventobj);
            return eventobj.Id;
        }
    }
}
