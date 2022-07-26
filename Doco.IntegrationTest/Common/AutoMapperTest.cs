using Microsoft.Extensions.DependencyInjection;

namespace Doco.IntegrationTest.Common
{
    public class AutoMapperTest : TestBase
    {
        [Test]
        public void AssertConfigurationIsValidShouldNotThrowAnException()
        {
            //arrange
            var sut = ServiceProvider.GetRequiredService<AutoMapper.IMapper>();

            //act
            //Assert
            Assert.DoesNotThrow(() =>
            {
                //checks whether all source-destination mapping profiles match
                //throws an exception if destination has a property which is not mapped to a source object's property
                sut.ConfigurationProvider.AssertConfigurationIsValid();
            });
        }
    }
}