using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Services.Entities.Responses
{
    public class Response : RxObject
    {
        public HttpStatusCode StatusCode => _restResponse.StatusCode;

        public Uri Uri => _restResponse.ResponseUri;

        private IRestResponse _restResponse;

        public IRestResponse RestResponse
        {
            get => _restResponse ?? (_restResponse = new RestResponse());
            set => _restResponse = value;
        }

        public Response(Response response)
        {
            _restResponse = response.RestResponse;
            try
            {
                Body = JObject.Parse(_restResponse.Content);
            }
            catch (JsonReaderException)
            {
                Body = JArray.Parse(_restResponse.Content);
            }
        }

        public Response(IRestResponse restResponse)
        {
            _restResponse = restResponse;
            try
            {
                Body = JObject.Parse(_restResponse.Content);
            }
            catch (JsonReaderException)
            {
                Body = JArray.Parse(_restResponse.Content);
            }
        }
    }
}
