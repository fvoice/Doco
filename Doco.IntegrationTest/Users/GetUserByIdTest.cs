using Doco.Application.Users.Queries.GetUserById;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Doco.IntegrationTest.Users
{
    public class GetUserByIdTest : UserTestBase
    {
        [Test]
        public async Task GetUserByIdTestShouldReturnData()
        {
            //arrange
            var sut = ServiceProvider.GetRequiredService<ISender>();
            var existing = await CreateNewUser();

            var request = new GetUserByIdQuery { Id = existing.Id };

            //act
            var result = await sut.Send(request);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(existing.Id);
        }
    }
}