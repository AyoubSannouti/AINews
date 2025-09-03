using AINews.Application.Contracts;
using AINews.Domain.Entities;
using AINews.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Persistance.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<ArticleCategory>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(AINewsDbContext ainewsDbContext) : base(ainewsDbContext)
        {

        }
        public async Task<IReadOnlyList<ArticleCategory>> GetAllArticleCategoriesAsync()
        {
            List<ArticleCategory> allArticleCategories = new List<ArticleCategory>();
            allArticleCategories = await _dbContext.ArticleCategory.ToListAsync();
            return allArticleCategories;
        }

        public async Task<ArticleCategory> GetArticleCategoryByIdAsync(Guid id)
        {
            ArticleCategory articleCategory = new ArticleCategory();
            articleCategory = await GetByIdAsync(id);
            return articleCategory;
        }


    }

}
