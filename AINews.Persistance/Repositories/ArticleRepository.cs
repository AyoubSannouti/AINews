using AINews.Domain.Entities;
using AINews.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AINews.Persistance.Data;

namespace AINews.Persistance.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(AINewsDbContext ainewsDbContext) : base(ainewsDbContext)
        {

        }
        public async Task<IReadOnlyList<Article>> GetAllArticlesAsync(bool includeCategory)
        {
            List<Article> allArticles = new List<Article>();
            allArticles = includeCategory ? await _dbContext.Article.Include(x => x.ArticleCategory).ToListAsync() : await _dbContext.Article.ToListAsync();
            return allArticles;
        }

        public async Task<Article> GetArticleByIdAsync(Guid id, bool includeCategory)
        {
            Article article = new Article();
            article = includeCategory ? await _dbContext.Article.Include(x => x.ArticleCategory).FirstOrDefaultAsync(x => x.Id == id) : await GetByIdAsync(id);
            return article;
        }


    }
}
