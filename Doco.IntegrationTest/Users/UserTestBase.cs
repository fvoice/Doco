using Doco.Application.Interfaces.Repositories;
using Doco.Domain.Entities;
using Doco.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Doco.IntegrationTest.Users
{
    public abstract class UserTestBase : TestBase
    {
        protected async Task<User> CreateNewUser()
        {
            var repo = ServiceProvider.GetRequiredService<IUserRepository>();
            var key = Guid.NewGuid().ToString();
            var existing = new User
            {
                Name = key,
                Email = $"{key}@test.com",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                Type = UserType.External
            };
            await repo.Create(existing);
            existing = Clone(existing); //clone to change the reference

            return existing;
        }
    }
}
