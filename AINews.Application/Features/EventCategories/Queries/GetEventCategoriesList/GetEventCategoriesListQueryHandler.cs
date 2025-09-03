using AINews.Application.Contracts;
using AINews.Application.Features.ArticleCategories.Queries.GetArticleCategoriesList;
using AINews.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.EventCategories.Queries.GetEventCategoriesList
{
    internal class GetEventCategoriesListQueryHandler : IRequestHandler<GetEventCategoriesListQuery, List<EventCategory>>
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;
        private readonly IMapper _mapper;

        public GetEventCategoriesListQueryHandler(IEventCategoryRepository eventCategoryRepository, IMapper mapper)
        {
            _eventCategoryRepository = eventCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<EventCategory>> Handle(GetEventCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allEventCategories = await _eventCategoryRepository.GetAllEventCategoriesAsync();
            return _mapper.Map<List<EventCategory>>(allEventCategories);
        }
    }
}
