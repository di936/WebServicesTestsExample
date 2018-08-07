namespace Services.Entities.Interfaces
{
    public interface IProject
    {
        string Id { get; set; }

        string Name { get; set; }

        string Path { get; set; }

        string Description { get; set; }
    }
}
