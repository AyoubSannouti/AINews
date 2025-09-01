using AINews.Domain.Entities;
using AINews.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Persistance.Repositories
{
    internal class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(AINewsDbContext ainewsDbContext) : base(ainewsDbContext)
        {

        }
        public async Task<IReadOnlyList<Event>> GetAllEventsAsync(bool includeCategory)
        {
            List<Event> allEvents = new List<Event>();
            allEvents = includeCategory ? await _dbContext.Event.Include(x => x.EventCategory).ToListAsync() : await _dbContext.Event.ToListAsync();
            return allEvents;
        }

        public async Task<Event> GetEventByIdAsync(Guid id, bool includeCategory)
        {
            Event eventobj = new Event();
            eventobj = includeCategory ? await _dbContext.Event.Include(x => x.EventCategory).FirstOrDefaultAsync(x => x.Id == id) : await GetByIdAsync(id);
            return eventobj;
        }


    }

}
