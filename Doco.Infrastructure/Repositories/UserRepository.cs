using System.Collections.Generic;
using System.Threading.Tasks;
using Doco.Application.Interfaces.Repositories;
using Doco.Domain.Entities;
using Doco.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Doco.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DocoDbContext _dbContext;

        public UserRepository(DocoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<User?>> GetAll()
        {
            return (await _dbContext.Users.ToListAsync()).AsReadOnly();
        }

        public async Task<User?> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x != null && x.Id == id);
        }

        public async Task<int> Create(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task Update(User user)
        {
            //nothing to do with the object basically, just save the tracked and changed objects
            await _dbContext.SaveChangesAsync();
        }
    }
}
