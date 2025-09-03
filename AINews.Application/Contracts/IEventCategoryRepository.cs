using AINews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Contracts
{
    public interface IEventCategoryRepository : IAsyncRepository<EventCategory>
    {
        Task<EventCategory> GetEventCategoryByIdAsync(Guid id);
        Task<IReadOnlyList<EventCategory>> GetAllEventCategoriesAsync();
    }
}