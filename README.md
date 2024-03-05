# SimpleMapper
The Simplest mapper possible with DI included. Define the mapper function in once side and use it everywhere

# How to use it
You can get the service from the serviceProvider

´´´C#
var mapper = serviceProvider.GetService<ISimpleMapper>();
´´´

Or use the interface in your class.
´´´C#
public Controller(ISimpleMapper simpleMapper){
    ...
}
´´´

Then you can map the object specifying the source and target class.
´´´C#
var userDto = simpleMapper.Map<User, UserDTO>(user);
´´´

or just the source class. You can only set only class using this way.
´´´C#
var userDto = simpleMapper.Map<User>(user);
´´´

# How to create Mapper classes

Implement the IClassMapper. Then the FunctionSimpleMapper.Extensions will get the binding function.
´´´C#
public class UserMapper : IClassMapper
{
    public void Bind(ISimpleMapper mapper)
    {
        mapper.Bind((User s) => new UserDTO()
            {
                Id = s.Id,
                Name = s.Name,
            });
    }
}
´´´

Add the service to de ServiceCollection.
´´´c#
var serviceProvider = new ServiceCollection()
                .AddSimpleMapper() <-- Add this line
                .BuildServiceProvider();
´´´


