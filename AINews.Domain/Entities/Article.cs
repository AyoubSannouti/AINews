using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Domain.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl{ get; set; }        
        public DateTime PublishedDate { get; set; }
        public Guid CategoryId { get; set; }
        public ArticleCategory ArticleCategory { get; set; }

        // User relationships (using Domain User ID)
        public string AuthorId { get; set; }
        public User? Author { get; set; }  // Navigation property
    }
}