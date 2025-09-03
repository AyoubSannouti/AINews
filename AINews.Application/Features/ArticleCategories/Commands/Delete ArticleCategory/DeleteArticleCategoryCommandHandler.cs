using AINews.Application.Contracts;
using AINews.Application.Features.Articles.Commands.DeleteArticle;
using MediatR;

namespace AINews.Application.Features.ArticleCategories.Commands.Delete_ArticleCategory
{
    internal class DeleteArticleCategoryCommandHandler : IRequestHandler<DeleteArticleCategoryCommand>
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public DeleteArticleCategoryCommandHandler(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;

        }
        public async Task<Unit> Handle(DeleteArticleCategoryCommand request, CancellationToken cancellationToken)
        {
            var articleCategory = await _articleCategoryRepository.GetByIdAsync(request.ArticleCategoryId);

            if (articleCategory == null)
            {
                throw new Exception("Article Category not found");
            }
            await _articleCategoryRepository.DeleteAsync(articleCategory);
            return Unit.Value;
        }
    }
}
