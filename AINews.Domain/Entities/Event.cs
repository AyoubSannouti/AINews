using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }

        // Event Cateogry relationships 
        public Guid CategoryId { get; set; }
        public EventCategory EventCategory { get; set; }

        public string CreatedById { get; set; } 
    }
}
