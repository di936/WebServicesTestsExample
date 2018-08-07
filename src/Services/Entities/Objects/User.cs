using Services.Entities.Interfaces;

namespace Services.Entities.Objects
{
    public class User : IUser, IEntity
    {
        public User() { }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }
}
