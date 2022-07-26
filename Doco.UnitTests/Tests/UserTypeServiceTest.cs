using Doco.Application.Services;
using Doco.Domain;
using Doco.Domain.Entities;
using Doco.Domain.Enums;
using FluentAssertions;

namespace Doco.UnitTests.Tests
{
    public class UserTypeServiceTest
    {
        private static object[] _source =
        {
            new object[] { new User {Email = $"mail{DomainConstants.CompanyEmailPostfix}"}, UserType.Internal },
            new object[] { new User {Email = $"mail@any.com"}, UserType.External }
        };

        [Test]
        [TestCaseSource(nameof(_source))]
        public async Task CalculateUserTypeShouldCalculateTypeCorrectly(User user, UserType expectedType)
        {
            //Arrange
            var sut = new UserTypeService();

            //Act
            var result = await sut.CalculateUserType(user);

            //Assert
            result.Should().Be(expectedType);
        }
    }
}