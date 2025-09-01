using AINews.Application.Features.Events.Commands.CreateEvent;
using AINews.Application.Features.Events.Commands.DeleteEvent;
using AINews.Application.Features.Events.Commands.UpdateEvent;
using AINews.Application.Features.Events.Queries.GetEventDetail;
using AINews.Application.Features.Events.Queries.GetEventsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AINews.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
            private readonly IMediator _mediator;

            public EventController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet("all", Name = "GetAllEvents")]
            public async Task<ActionResult<List<GetEventsListViewModel>>> GetAllEvents()
            {
                var dtos = await _mediator.Send(new GetEventsListQuery());
                return Ok(dtos);
            }

            [HttpGet("{id}", Name = "GetEventById")]
            public async Task<ActionResult<GetEventDetailViewModel>> GetArticleById(Guid id)
            {
                var getEventDetailQuery = new GetEventDetailQuery() { EventId = id };
                return Ok(await _mediator.Send(getEventDetailQuery));
            }

            [HttpPost(Name = "AddEvent")]
            public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand createEventCommand)
            {
                Guid id = await _mediator.Send(createEventCommand);
                return Ok(id);
            }

            [HttpPut(Name = "UpdateEvent")]
            public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
            {
                await _mediator.Send(updateEventCommand);
                return NoContent();
            }

            [HttpDelete("{id}", Name = "DeleteEvent")]
            public async Task<ActionResult> Delete(Guid id)
            {
                var deleteEventCommand = new DeleteEventCommand() { EventId = id };
                await _mediator.Send(deleteEventCommand);
                return NoContent();
            }

        }
    
}
