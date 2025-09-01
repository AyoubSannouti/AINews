using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Domain.Entities
{
    public class EventCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
