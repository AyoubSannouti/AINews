using AINews.Application.Features.EventCategories.Commands.CreateEventCategory;
using AINews.Application.Features.EventCategories.Commands.DeleteEventCategory;
using AINews.Application.Features.EventCategories.Commands.UpdateEventCategory;
using AINews.Application.Features.EventCategories.Queries.GetEventCategoriesList;
using AINews.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AINews.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllEventCategories")]
        public async Task<ActionResult<List<EventCategory>>> GetAllEventCategories()
        {
            var eventCategory = await _mediator.Send(new GetEventCategoriesListQuery());
            return Ok(eventCategory);
        }

        [HttpPost(Name = "AddEventCategory")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCategoryCommand createEventCategoryCommand)
        {
            Guid id = await _mediator.Send(createEventCategoryCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateEventCategory")]
        public async Task<ActionResult> Update([FromBody] UpdateEventCategoryCommand updateEventCategoryCommand)
        {
            await _mediator.Send(updateEventCategoryCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEventCategory")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEventCategoryCommand = new DeleteEventCategoryCommand() { EventCategoryId = id };
            await _mediator.Send(deleteEventCategoryCommand);
            return NoContent();
        }
    }
}
