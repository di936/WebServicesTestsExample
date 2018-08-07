using System;
using System.Collections.Generic;
using RestSharp;
using Services.Config;
using Services.Entities.Objects;
using Services.Entities.Requests;
using Services.Entities.Responses;

namespace Services.Services
{
    public class GitLabService : WebService, IDisposable
    {
        private static readonly string GitlabUrl = GitLab.Default.Url;
        private static readonly string ProjectsResource = GitLab.Default.ProjectsResource;
        private static readonly string UsersResource = GitLab.Default.UsersResource;
        private static readonly string MembersResource = GitLab.Default.MembersResource;

        private IDictionary<string,string> _defaultHeaders;
        private string _privateTokenHeaderName = "Private-Token";

        public Uri GetAllUsersUrl(string projectId) => new Uri(GitlabUrl + ProjectsResource + "/" + projectId + MembersResource);
        public Uri GetProjectUrl(string projectId) => new Uri(GitlabUrl + ProjectsResource + "/" + projectId);
        public Uri CreateProjectUrl() => new Uri(GitlabUrl + ProjectsResource);
        public Uri UpdateProjectUrl(string projectId) => new Uri(GitlabUrl + ProjectsResource + "/" + projectId);
        public Uri DeleteProjectUrl(string projectId) => new Uri(GitlabUrl + ProjectsResource + "/" + projectId);
        public Uri GetProjectUserUrl(string projectId, string userId) => new Uri(GitlabUrl + ProjectsResource + "/" + projectId + "/members/" + userId);
        public Uri GetProjectOwnerUrl(string projectId) => new Uri(GitlabUrl + ProjectsResource + "/" + projectId);
        public Uri GetUserProjectsUrl(string userId) => new Uri(GitlabUrl + UsersResource + "/" + userId + ProjectsResource);

        public GitLabService(string privateToken)
        {
            _defaultHeaders = new Dictionary<string, string>();
            _defaultHeaders.Add(new KeyValuePair<string, string>(_privateTokenHeaderName,privateToken));
        }

        public UserArrayResponse GetAllUsers(string projectId)
        {
            var request = new Request()
            {
                Headers = _defaultHeaders,
                Uri = GetAllUsersUrl(projectId)
            };

            return new UserArrayResponse(request.Send());
        }

        public ProjectResponse GetProject(string projectId)
        {
            var request = new Request
            {
                Headers = _defaultHeaders,
                Uri = GetProjectUrl(projectId)
            };

            return new ProjectResponse(request.Send());
        }

        public UserResponse GetProjectUser(string projectId, string userId)
        {
            var request = new Request
            {
                Headers = _defaultHeaders,
                Uri = GetProjectUserUrl(projectId, userId)
            };

            return new UserResponse(request.Send());
        }

        public UserResponse GetProjectOwner(string projectId)
        {
            var request = new Request
            {
                Headers = _defaultHeaders,
                Uri = GetProjectOwnerUrl(projectId)
            };

            return new UserResponse(request.Send());
        }

        public ProjectArrayResponse GetUserProjects(string userId)
        {
            var request = new Request
            {
                Headers = _defaultHeaders,
                Uri = GetUserProjectsUrl(userId)
            };

            return new ProjectArrayResponse(request.Send());
        }

        public ProjectResponse CreateProject(Project project)
        {
            var request = new ProjectRequest(project)
            {
                Headers = _defaultHeaders,
                Uri = CreateProjectUrl(),
                Method = Method.POST
            };

            return new ProjectResponse(request.Send());
        }

        public ProjectResponse UpdateProject(string projectId, Project changes)
        {
            var request = new ProjectRequest(changes)
            {
                Headers = _defaultHeaders,
                Uri = UpdateProjectUrl(projectId),
                Method = Method.PUT
            };

            return new ProjectResponse(request.Send());
        }

        public Response DeleteProject(string projectId)
        {
            var request = new Request()
            {
                Headers = _defaultHeaders,
                Uri = DeleteProjectUrl(projectId),
                Method = Method.DELETE
            };

            return new Response(request.Send());
        }

        public void Dispose()
        {

        }
    }
}
