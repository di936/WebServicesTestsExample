using Services.Entities.Interfaces;

namespace Services.Entities.Objects
{
    public class Project : IProject, IEntity
    {
        public Project() { }
        public string Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Created_At { get; set; }
        public string Web_Url { get; set; }
        public User Owner { get; set; }
        public string Path { get; set; }
    }
}
