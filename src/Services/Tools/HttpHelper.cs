using RestSharp;
using Services.Entities.Requests;
using Services.Entities.Responses;

namespace Services.Tools
{
    public class HttpHelper
    {
        public static Response SendRequest(Request request)
        {
            var client = new RestClient
            {
                BaseUrl = request.Uri
            };;

            var restRequest = new RestRequest(request.Method);
            restRequest.AddParameter(
                "application/json", 
                JsonHelper.Serialize(request.Body), 
                ParameterType.RequestBody
            );

            foreach (var header in request.Headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }

            var result = client.Execute(restRequest);
            client.BaseUrl = null;
            return new Response(result);
        }
    }
}
