using System;
using RestSharp;
using Services.Entities.Responses;
using Services.Tools;

namespace Services.Entities.Requests
{
    public class Request : RxObject
    {
        public Method Method
        {
            get => RestRequest.Method;
            set => RestRequest.Method = value;
        }

        public Uri Uri
        {
            get => new Uri(RestRequest.Resource);
            set => RestRequest.Resource = value.ToString();
        }

        private IRestRequest _restRequest;
        private IRestRequest RestRequest => _restRequest ?? (_restRequest = new RestRequest());

        public virtual Response Send() 
        {
            return HttpHelper.SendRequest(this);
        }
    }
}
