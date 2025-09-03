using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.ArticleCategories.Commands.Delete_ArticleCategory
{
    public class DeleteArticleCategoryCommand : IRequest
    {
        public Guid ArticleCategoryId { get; set; }
    }
}
