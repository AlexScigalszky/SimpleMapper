using MappearTests.Models;
using Microsoft.Extensions.DependencyInjection;
using SimpleMapper;
using SimpleMapper.ServiceDiscovery;

namespace Mappear.Tests
{
    [TestClass()]
    public class SimpleMapperServiceDiscoveryTests
    {
        [TestMethod()]
        public void GivenBindedAndDI_WhenMap_ThenSuccessTargets()
        {
            var source = Source.Simple();

            var serviceProvider = new ServiceCollection()
                .AddSimpleMapper()
                .BuildServiceProvider();

            var mapper = serviceProvider.GetService<ISimpleMapper>();

            var actual = mapper?.Map<Source, Target>(source);
            var actual2 = mapper?.Map<Source, Target2>(source);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType<Target>(actual);
            Assert.AreEqual(source.Id, actual.Id);
            Assert.AreEqual(source.Name, actual.Name);
            Assert.AreEqual(source.Description, actual.Description);

            Assert.IsNotNull(actual2);
            Assert.IsInstanceOfType<Target2>(actual2);
            Assert.AreEqual(source.Id, actual2.Id);
            Assert.AreEqual(source.Name, actual2.Name);
            Assert.AreEqual(source.Description, actual2.Description);
        }
    }
}