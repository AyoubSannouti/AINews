// tests/AINews.Api.Tests/Integration/AuthEndpointsTests.cs
using AINews.Application.Features.Authentication.Commands;
using AINews.Application.Features.Authentication.Queries.Me;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;
using Xunit;

public class AuthEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public AuthEndpointsTests(WebApplicationFactory<Program> factory) => _factory = factory;

    [Fact]
    public async Task Me_Should_Return_Unauthorized_When_No_Token()
    {
        var client = _factory.CreateClient();
        var res = await client.GetAsync("/api/Auth/me");
        res.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Register_Then_Me_Should_Return_Profile()
    {
        var client = _factory.CreateClient();

        var reg = await client.PostAsJsonAsync("/api/Auth/register", new
        {
            email = "test@site.com",
            password = "P@ssw0rd!",
            firstName = "Test",
            lastName = "User"
        });
        reg.EnsureSuccessStatusCode();
        var tokens = await reg.Content.ReadFromJsonAsync<AuthResultDto>();

        client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokens!.AccessToken);

        var me = await client.GetFromJsonAsync<MeDto>("/api/Auth/me");
        me!.Email.Should().Be("test@site.com");
    }
}
