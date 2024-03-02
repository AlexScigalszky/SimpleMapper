namespace MappearTests.Models
{
    public class Target
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public static Target Simple() => new()
        {
            Id = 1,
            Name = "test",
            Description = "test",
        };
    }
}
