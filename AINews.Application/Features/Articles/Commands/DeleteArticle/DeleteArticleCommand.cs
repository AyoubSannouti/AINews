using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommand : IRequest
    {
        public Guid ArticleId { get; set; }
    }
}
