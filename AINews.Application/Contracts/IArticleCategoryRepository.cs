using AINews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Contracts
{
    public interface IArticleCategoryRepository : IAsyncRepository<ArticleCategory>
    {
        Task<ArticleCategory> GetArticleCategoryByIdAsync(Guid id);
        Task<IReadOnlyList<ArticleCategory>> GetAllArticleCategoriesAsync();
    }
}
