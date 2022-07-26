using System.Threading.Tasks;
using Doco.Domain.Entities;
using Doco.Domain.Enums;

namespace Doco.Application.Interfaces.Services
{
    public interface IUserTypeService
    {
        Task<UserType> CalculateUserType(User user);
    }
}