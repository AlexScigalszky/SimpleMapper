namespace SimpleMapper.Console
{
    public class DirectMapping
    {
        public static string Run()
        {
            var user = new User()
            {
                Name = "Jonh",
                Age = 33,
                Created = DateTime.Now,
            };

            var mapper = new SimpleMapper();
            mapper.Bind((User user) => new UserDTO()
            {
                Name = user.Name,
                Age = user.Age,
                Created = user.Created,
            });

            var userDto = mapper.Map<User, UserDTO>(user);
            return
                $"{userDto?.GetType()} => " +
                $"Name: {userDto?.Age}," +
                $"Age: {userDto?.Age}," +
                $"Created: {userDto?.Created}"
            ;
        }
    }
}
