using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl{ get; set; }        
        public DateTime PublishedDate { get; set; }
        public Guid CategoryId { get; set; }

        public Guid AuthorId { get; set; }
    }
}
