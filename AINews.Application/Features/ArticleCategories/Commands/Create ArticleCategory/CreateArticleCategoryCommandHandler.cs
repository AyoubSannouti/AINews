using AINews.Application.Contracts;
using AINews.Application.Features.Articles.Commands.CreateArticle;
using AINews.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.ArticleCategories.Commands.Create_ArticleCategory
{
    public class CreateArticleCategoryCommandHandler : IRequestHandler<CreateArticleCategoryCommand, Guid>
    {
        private readonly IArticleCategoryRepository _articleCateogryRepository;
        private readonly IMapper _mapper;
        public CreateArticleCategoryCommandHandler(IArticleCategoryRepository articleCateogryRepository, IMapper mapper)
        {
            _articleCateogryRepository = articleCateogryRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateArticleCategoryCommand request, CancellationToken cancellationToken)
        {
            ArticleCategory articleCateogry = _mapper.Map<ArticleCategory>(request);
            CreateCommandValidator Validator = new CreateCommandValidator();
            var validationResult = await Validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new Exception("Article Category is not valid");
            }

            articleCateogry = await _articleCateogryRepository.AddAsync(articleCateogry);

            return articleCateogry.Id;
        }
    }
}
