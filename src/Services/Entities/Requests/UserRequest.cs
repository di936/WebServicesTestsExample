using Services.Entities.Interfaces;
using Services.Entities.Objects;

namespace Services.Entities.Requests
{
    public class UserRequest : Request, IUser
    {
        private const string IdProperty = "id";
        private const string NameProperty = "name";
        private const string UsernameProperty = "username";
        public string Id
        {
            get => GetNodeValue<string>(IdProperty);
            set => SetNodeValue(IdProperty, value);
        }

        public string Name
        {
            get => GetNodeValue<string>(NameProperty);
            set => SetNodeValue(NameProperty, value);
        }

        public string Username
        {
            get => GetNodeValue<string>(UsernameProperty);
            set => SetNodeValue(UsernameProperty, value);
        }
    }
}
