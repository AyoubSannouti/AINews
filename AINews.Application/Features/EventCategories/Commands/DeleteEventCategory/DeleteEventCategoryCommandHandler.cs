using AINews.Application.Contracts;
using AINews.Application.Features.ArticleCategories.Commands.Delete_ArticleCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.EventCategories.Commands.DeleteEventCategory
{
    internal class DeleteEventCategoryCommandHandler : IRequestHandler<DeleteEventCategoryCommand>
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public DeleteEventCategoryCommandHandler(IEventCategoryRepository eventCategoryRepository)
        {
            _eventCategoryRepository = eventCategoryRepository;

        }
        public async Task<Unit> Handle(DeleteEventCategoryCommand request, CancellationToken cancellationToken)
        {
            var eventCategory = await _eventCategoryRepository.GetByIdAsync(request.EventCategoryId);

            if (eventCategory == null)
            {
                throw new Exception("Event Category not found");
            }
            await _eventCategoryRepository.DeleteAsync(eventCategory);
            return Unit.Value;
        }
    }
}
