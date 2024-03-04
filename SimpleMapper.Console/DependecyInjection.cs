using Microsoft.Extensions.DependencyInjection;
using SimpleMapper.ServiceDiscovery;

namespace SimpleMapper.Console
{
    public class DependecyInjection
    {
        public static string Run()
        {
            var user = new User()
            {
                Name = "Jonh",
                Age = 33,
                Created = DateTime.Now,
            };

            var serviceProvider = new ServiceCollection()
                .AddSimpleMapper()
                .BuildServiceProvider();

            var mapper = serviceProvider.GetService<ISimpleMapper>();

            var userDto = mapper?.Map<User, UserDTO>(user);
            return
                $"{userDto?.GetType()} => " +
                $"Name: {userDto?.Age}," +
                $"Age: {userDto?.Age}," +
                $"Created: {userDto?.Created}"
            ;
        }
    }

    public class UserToUserDto : IClassMapper
    {
        public void Bind(ISimpleMapper mapper)
        {
            mapper.Bind((User user) => new UserDTO()
            {
                Name = user.Name,
                Age = user.Age,
                Created = user.Created,
            });
        }
    }
}
