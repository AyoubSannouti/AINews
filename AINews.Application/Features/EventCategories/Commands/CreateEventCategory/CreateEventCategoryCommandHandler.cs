using AINews.Application.Contracts;
using AINews.Application.Features.ArticleCategories.Commands.Create_ArticleCategory;
using AINews.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.EventCategories.Commands.CreateEventCategory
{
    internal class CreateEventCategoryCommandHandler : IRequestHandler<CreateEventCategoryCommand, Guid>
    {
        private readonly IEventCategoryRepository _eventCateogryRepository;
        private readonly IMapper _mapper;
        public CreateEventCategoryCommandHandler(IEventCategoryRepository eventCateogryRepository, IMapper mapper)
        {
            _eventCateogryRepository = eventCateogryRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateEventCategoryCommand request, CancellationToken cancellationToken)
        {
            EventCategory eventCateogry = _mapper.Map<EventCategory>(request);
            CreateCommandValidator Validator = new CreateCommandValidator();
            var validationResult = await Validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new Exception("Event Category is not valid");
            }

            eventCateogry = await _eventCateogryRepository.AddAsync(eventCateogry);

            return eventCateogry.Id;
        }
    }
}
