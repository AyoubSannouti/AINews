using AINews.Application.Contracts;
using AINews.Application.Features.Articles.Commands.DeleteArticle;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Events.Commands.DeleteEvent
{
    internal class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventobj = await _eventRepository.GetByIdAsync(request.EventId);

            if (eventobj == null) throw new Exception("Article not found");

            await _eventRepository.DeleteAsync(eventobj);
            return Unit.Value;
        }
    }
}
