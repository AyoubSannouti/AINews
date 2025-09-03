using AINews.Application.Features.Articles.Queries.GetArticlesList;
using AINews.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.ArticleCategories.Queries.GetArticleCategoriesList
{
    public class GetArticleCategoriesListQuery : IRequest<List<ArticleCategory>>
    {
    }
}
