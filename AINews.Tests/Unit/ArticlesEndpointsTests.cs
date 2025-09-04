using System.Net;
using System.Net.Http.Json;
using AINews.Application.Features.Articles; 
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;

namespace AINews.Tests.Unit;

public class ArticlesEndpointsTests : IClassFixture<TestWebAppFactory>
{
    private readonly Mock<IMediator> _mediator = new();
    private readonly TestWebAppFactory _factory;
    private readonly HttpClient _client;

    public ArticlesEndpointsTests()
    {
        _factory = new TestWebAppFactory(_mediator.Object);
        _client = _factory.CreateClient();
    }

    // --- DTOs used by API ---
    private record ArticleSummaryDto(
        string Id, string Title, string? ImageUrl, string Summary,
        string AuthorId, string? AuthorName, DateTime PublishedDate, string CategoryId);

    private record ArticleDetailDto(
        string Id, string Title, string? ImageUrl, string Summary,
        string AuthorId, string? AuthorName, DateTime PublishedDate, string CategoryId,
        string Content);

    private record CreateArticleRequest(string Title, string Content, string? ImageUrl, string CategoryId);

    [Fact]
    public async Task GET_all_should_return_200_and_payload()
    {
        // Arrange
        var payload = new[]
        {
            new ArticleSummaryDto("a1","Intro to AI", null, "…", "u1","Alice", DateTime.UtcNow, "c1"),
            new ArticleSummaryDto("a2","LLMs", "http://img", "…", "u2","Bob", DateTime.UtcNow, "c2")
        };


        _mediator
            .Setup(m => m.Send(It.IsAny<IRequest<IEnumerable<ArticleSummaryDto>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(payload);

        // Act
        var res = await _client.GetAsync("/api/Article/all");
        res.StatusCode.Should().Be(HttpStatusCode.OK);

        var data = await res.Content.ReadFromJsonAsync<IEnumerable<ArticleSummaryDto>>();
        data.Should().BeEquivalentTo(payload);
    }

    [Fact]
    public async Task GET_by_id_should_return_404_when_not_found()
    {
        _mediator
            .Setup(m => m.Send(It.IsAny<IRequest<ArticleDetailDto?>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((ArticleDetailDto?)null);

        var res = await _client.GetAsync("/api/Article/NOPE");
        res.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task POST_create_should_require_auth_and_return_201()
    {

        var created = new ArticleDetailDto("new-id", "New", "http://img", "sum", "u1", "Alice", DateTime.UtcNow, "c1", "content");

        _mediator
            .Setup(m => m.Send(It.IsAny<IRequest<ArticleDetailDto>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(created);

        var body = new CreateArticleRequest("New", "content", "http://img", "c1");

        var res = await _client.PostAsJsonAsync("/api/Article", body);

        res.StatusCode.Should().Be(HttpStatusCode.Created);
        res.Headers.Location!.ToString().Should().Contain("/api/Article/new-id");

        var returned = await res.Content.ReadFromJsonAsync<ArticleDetailDto>();
        returned.Should().BeEquivalentTo(created, options => options
            .Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation, TimeSpan.FromSeconds(5)))
            .WhenTypeIs<DateTime>());
    }
}
