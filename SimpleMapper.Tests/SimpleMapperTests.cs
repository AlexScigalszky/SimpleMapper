using MappearTests.Models;

namespace Mappear.Tests
{
    [TestClass()]
    public class SimpleMapperTests
    {
        [TestMethod()]
        public void GivenBinded_WhenMap_ThenSuccessTargets()
        {
            var source1 = Source.Simple();
            var source2 = Source2.Simple();
            var simpleMapper = new SimpleMapper();

            simpleMapper.Bind((Source s) => new Target()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
            });

            simpleMapper.Bind((Source2 s) => new Target2()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
            });

            Target actual1 = simpleMapper.Map<Source, Target>(source1);
            Target2 actual2 = simpleMapper.Map<Source2, Target2>(source2);

            Assert.IsNotNull(actual1);
            Assert.IsInstanceOfType<Target>(actual1);
            Assert.AreEqual(source1.Id, actual1.Id);
            Assert.AreEqual(source1.Name, actual1.Name);
            Assert.AreEqual(source1.Description, actual1.Description);

            Assert.IsNotNull(actual2);
            Assert.IsInstanceOfType<Target2>(actual2);
            Assert.AreEqual(source2.Id, actual2.Id);
            Assert.AreEqual(source2.Name, actual2.Name);
            Assert.AreEqual(source2.Description, actual2.Description);
        }

        [TestMethod()]
        public void GivenNotBinded_WhenMap_ThenThrowNotSupportedException()
        {
            var simpleMapper = new SimpleMapper();
            var source = Source.Simple();

            Assert.ThrowsException<NotSupportedException>(() => simpleMapper.Map<Source, Target>(source), "Mapper function not found");
        }

        [TestMethod()]
        public void GivenBindFnError_WhenMap_ThenThrowException()
        {
            var simpleMapper = new SimpleMapper();
            var source = Source.Simple();
            simpleMapper.Bind((Source s) => throw new Exception("exception forced"));

            Assert.ThrowsException<Exception>(() => simpleMapper.Map<Source, Target>(source), "Unexpected error");
        }

        [TestMethod()]
        public void GivenBindFnErrorAndErrorHandling_WhenMap_ThenThrowException()
        {
            var simpleMapper = new SimpleMapper(new() { ExceptionHandling = true });
            var source1 = Source.Simple();
            var source2 = Source2.Simple();
            simpleMapper.Bind((Source s) => throw new Exception("exception forced"));

            var actual1 = simpleMapper.Map<Source, Target>(source1);
            var actual2 = simpleMapper.Map<Source2, Target>(source2);

            Assert.IsNull(actual1);
            Assert.IsNull(actual2);
        }
    }
}