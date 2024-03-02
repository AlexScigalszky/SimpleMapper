namespace MappearTests.Models
{
    public class Source2
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public static Source2 Simple() => new()
        {
            Id = 2,
            Name = "test 2",
            Description = "test 2",
        };
    }
}
