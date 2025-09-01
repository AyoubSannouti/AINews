using AINews.Application.Features.Articles.Queries.GetArticlesList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Articles.Queries.GetArticleDetail
{
    public class GetArticleDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
