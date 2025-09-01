using AINews.Domain.Entities;


namespace AINews.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public EventCategory Category { get; set; }
    }
}
