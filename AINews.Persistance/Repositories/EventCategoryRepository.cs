using AINews.Application.Contracts;
using AINews.Domain.Entities;
using AINews.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Persistance.Repositories
{
    internal class EventCategoryRepository : BaseRepository<EventCategory>, IEventCategoryRepository
    {
        public EventCategoryRepository(AINewsDbContext ainewsDbContext) : base(ainewsDbContext)
        {

        }
        public async Task<IReadOnlyList<EventCategory>> GetAllEventCategoriesAsync()
        {
            List<EventCategory> allEventCategories = new List<EventCategory>();
            allEventCategories = await _dbContext.EventCategory.ToListAsync();
            return allEventCategories;
        }

        public async Task<EventCategory> GetEventCategoryByIdAsync(Guid id)
        {
            EventCategory eventCategory = new EventCategory();
            eventCategory = await GetByIdAsync(id);
            return eventCategory;
        }
    }
}
