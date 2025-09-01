using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AINews.Domain.Entities;
namespace AINews.Application.Contracts
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<Event> GetEventByIdAsync(Guid id, bool includeCategory);

        Task<IReadOnlyList<Event>> GetAllEventsAsync(bool includeCategory);
    }
}
