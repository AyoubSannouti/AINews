using AINews.Application.Contracts;
using AINews.Application.Features.ArticleCategories.Commands.Update_ArticleCategory;
using AINews.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AINews.Application.Features.EventCategories.Commands.UpdateEventCategory
{
    internal class UpdateEventCategoryCommandHandler : IRequestHandler<UpdateEventCategoryCommand>
    {
        private readonly IAsyncRepository<EventCategory> _eventCategoryRepository;
    private readonly IMapper _mapper;
    public UpdateEventCategoryCommandHandler(IAsyncRepository<EventCategory> eventCategoryRepository, IMapper mapper)
    {
        _eventCategoryRepository = eventCategoryRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateEventCategoryCommand request, CancellationToken cancellationToken)
    {
        EventCategory articleCategory = _mapper.Map<EventCategory>(request);
        await _eventCategoryRepository.UpdateAsync(articleCategory);
        return Unit.Value;
    }
}
}
