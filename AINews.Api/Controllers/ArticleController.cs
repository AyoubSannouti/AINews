using AINews.Application.Features.Articles.Queries.GetArticlesList;
using AINews.Application.Features.Articles.Queries.GetArticleDetail;
using AINews.Application.Features.Articles.Commands.UpdateArticle;
using AINews.Application.Features.Articles.Commands.CreateArticle;
using AINews.Application.Features.Articles.Commands.DeleteArticle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AINews.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllArticles")]
        public async Task<ActionResult<List<GetArticlesListViewModel>>> GetAllArticles()
        {
            var dtos = await _mediator.Send(new GetArticlesListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetArticleById")]
        public async Task<ActionResult<GetArticleDetailViewModel>> GetArticleById(Guid id)
        {
            var getEventDetailQuery = new GetArticleDetailQuery() { ArticleId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddArticle")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateArticleCommand createArticleCommand)
        {
            Guid id = await _mediator.Send(createArticleCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateArticle")]
        public async Task<ActionResult> Update([FromBody] UpdateArticleCommand updateArticleCommand)
        {
            await _mediator.Send(updateArticleCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteArticle")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePostCommand = new DeleteArticleCommand() { ArticleId = id };
            await _mediator.Send(deletePostCommand);
            return NoContent();
        }

    }
}
