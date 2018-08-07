using Services.Entities.Interfaces;
using Services.Entities.Objects;

namespace Services.Entities.Responses
{
    public class UserArrayResponse : Response, IUserArray
    {

        public UserArrayResponse(Response response)
            : base(response) { }

        public IUser[] Users
        {
            get => GetNodeArray<User>();
            set => SetNodeArray(value);
        }
    }
}
