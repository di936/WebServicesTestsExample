using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Services.Entities.Objects;
using Services.Entities.Responses;
using Services.Services;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Framework.Steps.Assertions.GitLab
{
    [Binding]
    public class Assertions
    {
        private string Token = Config.Default.GitLabToken;

        [Then(@"(Current|New|Updated) project has values:")]
        public void ProjectHasValues(string status, Table table)
        {
            var expected = table.CreateInstance<Project>();
            ProjectResponse actual;
            using (var service = new GitLabService(Token))
            {
                var projectId = ScenarioContext.Current["ProjectId"] as string;
                actual = service.GetProject(projectId);
            }

            // Rework later to "Not null field" expression or something else 
            Assert.That(expected.Name, Is.EqualTo(actual.Name));
            Assert.That(expected.Description, Is.EqualTo(actual.Description));
        }

        [Then(@"(Current|New|Updated) project contains user with id ""(.*)""")]
        public void ProjectHasUserWithId(string status, string userId)
        {
            string actual;
            using (var service = new GitLabService(Token))
            {
                var projectId = ScenarioContext.Current["ProjectId"] as string;
                actual = service.GetProjectUser(projectId, userId).Id;
            }

            Assert.That(userId, Is.EqualTo(actual));
        }

        [Then(@"Project with id ""(.*)"" has owner with id ""(.*)""")]
        public void ProjectWithIdHasOwnerWithId(string projectId, string ownerId)
        {
            string errorMessage = $"Repository with id {projectId} has no owner with id {ownerId}";
            using (var service = new GitLabService(Token))
            {
                Assert.That(service.GetProjectOwner(projectId).Id, Is.EqualTo(ownerId), errorMessage);
            }
        }

        [Then(@"Create project returns status code ""(.*)"" on project with values:")]
        public void GetProjectWithIdReturnsStatusCode(string statusCode, Table table)
        {
            string actual;
            using (var service = new GitLabService(Token))
            {
                actual = ((int)service.CreateProject(table.CreateInstance<Project>()).StatusCode).ToString();
            }

            Assert.That(actual, Is.EqualTo(statusCode));
        }

        [Then(@"Get current project returns status code ""(.*)""")]
        public void GetProjectWithIdReturnsStatusCode(string statusCode)
        {
            int actual;
            using (var service = new GitLabService(Token))
            {
                actual = (int)(service.GetProject(ScenarioContext.Current["ProjectId"] as string).StatusCode);
            }

            Assert.That(actual.ToString(), Is.EqualTo(statusCode));
        }

        [Then(@"Current project contains users with ids ""(.*)""")]
        public void ProjectWithIdContainsUsersWithIds(List<string> expectedIds)
        {
            List<string> actualIds;
            using (var service = new GitLabService(Token))
            {
                actualIds = service.GetAllUsers(ScenarioContext.Current["ProjectId"] as string).Users.Select(user => user.Id).ToList();
            }

            foreach (var id in expectedIds)
            {
                Assert.That(actualIds, Contains.Item(id));
            }
        }
    }
}
