using MappearTests.Models;

namespace SimpleMapper.Tests.Mappers
{
    public class UserToUserDtoTest : IClassMapper
    {
        public void Bind(ISimpleMapper mapper)
        {
            mapper.Bind((Source s) => new Target()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
            });

            mapper.Bind<Source, Target2>((Source s) => new Target2()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
            });
        }
    }
}
