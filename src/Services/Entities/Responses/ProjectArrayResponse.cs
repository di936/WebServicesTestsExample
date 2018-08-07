using Services.Entities.Interfaces;
using Services.Entities.Objects;

namespace Services.Entities.Responses
{
    public class ProjectArrayResponse : Response, IProjectArray
    {
        public ProjectArrayResponse(Response response)
            : base(response) { }

        public IProject[] Projects
        {
            get => GetNodeArray<Project>();
            set => SetNodeArray(value);
        }
    }
}
