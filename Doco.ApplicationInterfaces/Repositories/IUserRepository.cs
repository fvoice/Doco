using System.Collections.Generic;
using System.Threading.Tasks;
using Doco.Domain.Entities;

namespace Doco.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IReadOnlyCollection<User?>> GetAll();
        Task<User?> GetById(int id);
        Task<int> Create(User user);
        Task Update(User user);
    }
}