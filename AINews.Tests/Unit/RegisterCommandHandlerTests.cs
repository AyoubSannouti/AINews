using AINews.Application.Contracts;
using AINews.Application.Features.Authentication.Commands;
using AINews.Application.Features.Authentication.Commands.Register;
using FluentAssertions;
using Moq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AINews.Tests.Unit
{
    public class RegisterCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Create_User_And_Return_Tokens()
        {
            // Arrange
            var identity = new Mock<IIdentityService>();
            var jwt = new Mock<IJwtTokenGenerator>();

            // Match the EXACT signature/return type of IIdentityService.RegisterAsync:
            // Task<(bool success, string userId, string email, string userName, IEnumerable<string> errors)>
            identity
                .Setup(s => s.RegisterAsync("a@b.com", "pw"))
                .ReturnsAsync((true, "uid-1", "a@b.com", "Alice", Enumerable.Empty<string>()));

            // Match the EXACT signature/return type of IJwtTokenGenerator.Generate:
            // (string accessToken, string refreshToken) Generate(string userId, string email, string userName, IEnumerable<string> roles)
            jwt
                .Setup(j => j.Generate("uid-1", "a@b.com", "Alice", It.IsAny<IEnumerable<string>>()))
                .Returns(new AuthResultDto
                {
                    AccessToken = "access",
                    RefreshToken = "refresh"
                });

            var sut = new RegisterCommandHandler(identity.Object, jwt.Object);

            // If RegisterCommand has properties rather than a positional ctor, use an object initializer
            var command = new RegisterCommand
            {
                Email = "a@b.com",
                Password = "pw",
                FirstName = "Alice",
                LastName  = "Doe"
            };

            // Act
            var res = await sut.Handle(command, CancellationToken.None);

            // Assert
            res.AccessToken.Should().Be("access");
            res.RefreshToken.Should().Be("refresh");

            identity.Verify(s => s.RegisterAsync("a@b.com", "pw"), Times.Once);
            jwt.Verify(j => j.Generate("uid-1", "a@b.com", "Alice", It.IsAny<IEnumerable<string>>()), Times.Once);
        }
    }
}
