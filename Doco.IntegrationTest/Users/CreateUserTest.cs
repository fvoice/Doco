using Doco.Application.Interfaces.Repositories;
using Doco.Application.Users.Commands.CreateUserCommand;
using Doco.Domain.Entities;
using Doco.Domain.Enums;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Doco.IntegrationTest.Users
{
    public class CreateUserTest : UserTestBase
    {
        [Test]
        public async Task CreateUserCommandShouldCreateAnUser()
        {
            //arrange
            var sut = ServiceProvider.GetRequiredService<ISender>();
            var repo = ServiceProvider.GetRequiredService<IUserRepository>();
            var key = Guid.NewGuid().ToString();
            var request = new CreateUserCommand()
            {
                User = new User
                {
                     Name = key,
                     Email = $"{key}@test.com"
                }
            };

            //act
            var result = await sut.Send(request);
            var dbItem = await repo.GetById(result);

            //Assert
            result.Should().BeGreaterThan(0);
            dbItem.Should().NotBeNull();
            dbItem.Name.Should().BeEquivalentTo(key);
            dbItem.Email.Should().StartWith(key);
            dbItem.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(5000));
            dbItem.LastModified.Should().NotBeNull();
            dbItem.Type.Should().Be(UserType.External);
        }

        [Test]
        public async Task CreateUserCommandShouldValidateUser()
        {
            //arrange
            var sut = ServiceProvider.GetRequiredService<ISender>();
            var repo = ServiceProvider.GetRequiredService<IUserRepository>();
            var request = new CreateUserCommand()
            {
                User = new User
                {
                    Name = string.Empty,
                    Email = "wrong_mail"
                }
            };

            //act
            //Assert
            await FluentActions.Invoking(async () => await sut.Send(request))
                .Should().ThrowAsync<ValidationException>();
        }
    }
}