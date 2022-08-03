namespace MinimalApis.Data.Entities;

public class Car
{
    public int Id { get; set; }
    public string Make { get; set; } = default!;
    public string Model { get; set; } = default!;
}