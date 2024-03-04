using SimpleMapper.Console;

var user = new User()
{
    Name = "Jonh",
    Age = 33,
    Created = DateTime.Now,
};

var mapper = new SimpleMapper.SimpleMapper();
mapper.Bind((User user) => new UserDTO()
{
    Name = user.Name,
    Age = user.Age,
    Created = user.Created,
});

var userDto = mapper.Map<User, UserDTO>(user);
Console.WriteLine($"{userDto.GetType()} => Name: {userDto.Age},Name: {userDto.Age},Created: {userDto.Created}");