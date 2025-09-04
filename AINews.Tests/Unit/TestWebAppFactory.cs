using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace AINews.Tests;

public sealed class TestWebAppFactory : WebApplicationFactory<Program>
{
    private IMediator @object;

    public TestWebAppFactory(IMediator @object)
    {
        this.@object = @object;
    }
}
