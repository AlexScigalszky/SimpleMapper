namespace MappearTests.Models
{
    public class Source
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public static Source Simple() => new()
        {
            Id = 1,
            Name = "test",
            Description = "test",
        };
    }
}
