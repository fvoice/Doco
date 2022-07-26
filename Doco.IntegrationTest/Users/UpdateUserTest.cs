using Doco.Application.Interfaces.Repositories;
using Doco.Application.Users.Commands.UpdateUserCommand;
using Doco.Domain.Entities;
using Doco.Domain.Enums;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Doco.IntegrationTest.Users
{
    public class UpdateUserTest : UserTestBase
    {
        [Test]
        public async Task UpdateUserCommandShouldCreateAnUser()
        {
            //arrange
            var sut = ServiceProvider.GetRequiredService<ISender>();
            var repo = ServiceProvider.GetRequiredService<IUserRepository>();
            var existing = await CreateNewUser();
            var key = Guid.NewGuid().ToString();

            var request = new UpdateUserCommand()
            {
                User = new User
                {
                    Id = existing.Id,
                    Name = key,
                    Email = $"{key}@test.com"
                }
            };

            //act
            await sut.Send(request);
            var dbItem = await repo.GetById(request.User.Id);

            //Assert
            dbItem.Should().NotBeNull();
            dbItem.Name.Should().BeEquivalentTo(request.User.Name);
            dbItem.Email.Should().BeEquivalentTo(request.User.Email);
            dbItem.Created.Should().Be(existing.Created);
            dbItem.LastModified.Should().NotBe(existing.LastModified);
            dbItem.Type.Should().Be(UserType.External);
        }

        [Test]
        public async Task CreateUserCommandShouldValidateUser()
        {
            //arrange
            var sut = ServiceProvider.GetRequiredService<ISender>();
            var request = new UpdateUserCommand()
            {
                User = new User
                {
                    Id = 0,
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