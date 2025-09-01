using MediatR;
using System;

namespace AINews.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl{ get; set; }        
        public DateTime PublishedDate { get; set; }
        public Guid CategoryId { get; set; }
    }
}
