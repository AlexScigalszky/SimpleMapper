# SimpleMapper
The Simplest mapper possible with DI included. Define the mapper function on once side and use it everywhere

# How to use it
SimpleMapper Creation
```csharp
var mapper = new SimpleMapper();
```

You can get the service from the serviceProvider
```csharp
var mapper = serviceProvider.GetService<ISimpleMapper>();
```

Or use the interface in your class.
```csharp
public Controller(ISimpleMapper simpleMapper){
    ...
}
```

Then you can map the object specifying the source and target class.
```csharp
var userDto = simpleMapper.Map<User, UserDTO>(user);
```

or just the source class. You can only set only class this way.
```csharp
var userDto = simpleMapper.Map<User>(user);
```


# How to create Mapper function

Create a function a bind it to the mapper
```csharp
mapper.Bind((User s) => new UserDTO()
    {
        Id = s.Id,
        Name = s.Name,
    });
```
# How to create Mapper classes

Implement the IClassMapper. Then the FunctionSimpleMapper.Extensions will get the binding function.
```csharp
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
```

Add the service to de ServiceCollection.
```csharp
var serviceProvider = new ServiceCollection()
                .AddSimpleMapper() <-- Add this line
                .BuildServiceProvider();
```
