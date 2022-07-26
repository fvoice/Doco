using Doco.Application.Users.Queries.GetAllUsers;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Doco.IntegrationTest.Users
{
    public class GetAllUsersTest : UserTestBase
    {
        [Test]
        public async Task GetAllUsersQueryShouldReturnData()
        {
            //arrange
            var sut = ServiceProvider.GetRequiredService<ISender>();
            var existing = await CreateNewUser();

            var request = new GetAllUsersQuery();

            //act
            var result = await sut.Send(request);

            //Assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
            result.Should().Contain(x => x.Id == existing.Id);
        }
    }
}