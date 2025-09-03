using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.EventCategories.Commands.DeleteEventCategory
{
    public class DeleteEventCategoryCommand : IRequest
    {
        public Guid EventCategoryId { get; set; }
    }
}
