using System;
using System.Threading.Tasks;
using Doco.Application.Interfaces.Services;
using Doco.Domain;
using Doco.Domain.Entities;
using Doco.Domain.Enums;

namespace Doco.Application.Services
{
    public class UserTypeService : IUserTypeService
    {
        public Task<UserType> CalculateUserType(User user)
        {
            var result = user.Email.EndsWith(DomainConstants.CompanyEmailPostfix, StringComparison.InvariantCultureIgnoreCase) 
                ? UserType.Internal 
                : UserType.External;
            return Task.FromResult(result);
        }
    }
}