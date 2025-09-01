using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AINews.Domain.Entities;

namespace AINews.Application.Contracts
{
    public interface IArticleRepository : IAsyncRepository<Article>
    {
        Task<Article> GetArticleByIdAsync(Guid id, bool includeCategory);
        Task<IReadOnlyList<Article>> GetAllArticlesAsync(bool includeCategory);
    }
}
