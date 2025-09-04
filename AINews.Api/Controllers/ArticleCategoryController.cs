using AINews.Application.Features.ArticleCategories.Commands.Create_ArticleCategory;
using AINews.Application.Features.ArticleCategories.Commands.Delete_ArticleCategory;
using AINews.Application.Features.ArticleCategories.Commands.Update_ArticleCategory;
using AINews.Application.Features.ArticleCategories.Queries.GetArticleCategoriesList;
using AINews.Application.Features.Articles.Commands.CreateArticle;
using AINews.Application.Features.Articles.Commands.DeleteArticle;
using AINews.Application.Features.Articles.Commands.UpdateArticle;
using AINews.Application.Features.Articles.Queries.GetArticleDetail;
using AINews.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AINews.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllArticleCategories")]

        public async Task<ActionResult<List<ArticleCategory>>> GetAllArticleCategories()
        {
            var articleCategory = await _mediator.Send(new GetArticleCategoriesListQuery());
            return Ok(articleCategory);
        }

        [HttpPost(Name = "AddArticleCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateArticleCategoryCommand createArticleCategoryCommand)
        {
            Guid id = await _mediator.Send(createArticleCategoryCommand);
            return Ok(id);
        }

        [HttpPut("{id:guid}", Name = "UpdateArticleCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update([FromBody] UpdateArticleCategoryCommand updateArticleCategoryCommand)
        {
            await _mediator.Send(updateArticleCategoryCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteArticleCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteArticleCategoryCommand = new DeleteArticleCategoryCommand() { ArticleCategoryId = id };
            await _mediator.Send(deleteArticleCategoryCommand);
            return NoContent();
        }


    }
}
