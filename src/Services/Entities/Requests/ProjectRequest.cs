using Services.Entities.Interfaces;
using Services.Entities.Objects;
using Services.Tools;

namespace Services.Entities.Requests
{
    public class ProjectRequest : Request, IProject
    {
        private const string IdProperty = "id";
        private const string NameProperty = "name";
        private const string PathProperty = "path";
        private const string DescriptionProperty = "description";

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

        public string Description
        {
            get => GetNodeValue<string>(DescriptionProperty);
            set => SetNodeValue(DescriptionProperty, value);
        }

        public string Path
        {
            get => GetNodeValue<string>(PathProperty);
            set => SetNodeValue(PathProperty, value);
        }

        public ProjectRequest(Project project)
        {
            Body = JsonHelper.ToBody(project);
        }

    }
}
