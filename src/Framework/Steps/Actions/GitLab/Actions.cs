using Services.Entities.Objects;
using Services.Services;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Framework.Steps.Actions.GitLab
{
    [Binding]
    public class Actions
    {
        [Given(@"User creates new project:")]
        [When(@"User creates new project:")]
        public void UserCreatesNewProject(Table table)
        {
            var project = table.CreateInstance<Project>();
            using (var service = new GitLabService(Config.Default.GitLabToken))
            {
                ScenarioContext.Current["ProjectId"] = service.CreateProject(project).Id;
            }
        }

        [Given(@"User updates current project with values:")]
        [When(@"User updates current project with values:")]

        public void UserUpdatesProjectWithValues(Table table)
        {
            var project = table.CreateInstance<Project>();
            using (var service = new GitLabService(Config.Default.GitLabToken))
            { 
                service.UpdateProject(ScenarioContext.Current["ProjectId"] as string, project);
            }
        }

        [Given(@"User deletes current project")]
        [When(@"User deletes current project")]
        public void UserDeletesProject()
        {
            using (var service = new GitLabService(Config.Default.GitLabToken))
            {
                service.DeleteProject(ScenarioContext.Current["ProjectId"] as string);
            }
        }

        [Given(@"User uses project with id ""(.*)""")]
        [When(@"User uses project with id ""(.*)""")]
        public void SetProjectId(string id)
        {
            ScenarioContext.Current["ProjectId"] = id;
        }

        [Given(@"User uses user with id ""(.*)""")]
        [When(@"User uses user with id ""(.*)""")]
        public void SetUserId(string id)
        {
            ScenarioContext.Current["UserId"] = id;
        }
    }
}
