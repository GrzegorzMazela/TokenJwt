using Newtonsoft.Json;
using RestSharp;
using System;
using TokenJwt.ApiClient.Attributes;
using TokenJwt.Dto.Results;

namespace TokenJwt.ApiClient
{
    internal class RequestHelper
    {
        internal static RestRequest CreateRestRequestParsObjectAsParameter(string methodName, object parsObject, Method httpMethod = Method.GET)
        {
            var restRequest = new RestRequest(methodName, httpMethod);
            foreach (var prop in UrlNameHelper.GetRequestParameter(parsObject))
            {
                restRequest.AddParameter(prop.Key, prop.Value);
            }
            return restRequest;
        }

        internal static RestRequest CreateRestRequest(string methodName, Method httpMethod = Method.GET)
        {
            var restRequest = new RestRequest(methodName, httpMethod);
            return restRequest;
        }

        internal static RestRequest CreateRestRequestObjectAsParameter(string methodName, object parsObject, Method httpMethod = Method.GET)
        {
            var restRequest = new RestRequest(methodName, httpMethod);
            restRequest.AddObject(parsObject);
            return restRequest;
        }

        internal static RestRequest CreateRestRequestObjectAsBody(string methodName, object parsObject, Method httpMethod = Method.GET)
        {
            var restRequest = new RestRequest(methodName, httpMethod);
            var json = JsonConvert.SerializeObject(parsObject);
            restRequest.AddParameter("text/json", json, ParameterType.RequestBody);
            return restRequest;
        }

        internal static OperationResult SendRequest(string serviceUrl, RestRequest restRequest, bool resend = false)
        {
            var result = new OperationResult<string>();
            var client = new RestSharp.RestClient(serviceUrl);
            var response = client.Execute(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && !resend)
            {
                client = new RestSharp.RestClient(serviceUrl);
                response = client.Execute(restRequest);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.SetSucces(response.Content);
            }
            else
            {
                result.SetError(response);
            }

            return result;
        }

        internal static OperationResult<T> SendRequest<T>(string serviceUrl, RestRequest restRequest, bool resend = false) where T : new()
        {
            var result = new OperationResult<T>();
            var client = new RestSharp.RestClient(serviceUrl);
            var response = client.Execute<T>(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && !resend)
            {
                client = new RestSharp.RestClient(serviceUrl);
                response = client.Execute<T>(restRequest);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.SetSucces(response.Data);
            }
            else
            {
                result.SetError(response);
            }

            return result;
        }

        internal static OperationResult<string> SendRequest(string serviceUrl, RestRequest restRequest, string token, bool resend = false)
        {
            var result = new OperationResult<string>();
            var client = new RestSharp.RestClient(serviceUrl);
            client.AddDefaultHeader("Authorization", $"bearer {token}");
            var response = client.Execute(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && !resend)
            {
                client = new RestSharp.RestClient(serviceUrl);
                response = client.Execute(restRequest);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.SetSucces(response.Content);
            }
            else
            {
                result.SetError(response);
            }

            return result;
        }

        internal static OperationResult<T> SendRequest<T>(string serviceUrl, RestRequest restRequest, string token, bool resend = false) where T : new()
        {
            var result = new OperationResult<T>();
            var client = new RestSharp.RestClient(serviceUrl);
            client.AddDefaultHeader("Authorization", $"bearer {token}");
            var response = client.Execute<T>(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && !resend)
            {
                client = new RestSharp.RestClient(serviceUrl);
                response = client.Execute<T>(restRequest);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.SetSucces(response.Data);
            }
            else
            {
                result.SetError(response);
            }

            return result;
        }

        internal static OperationResult<string> SendRequest(string firstServiceUrl, string secondServiceUrl, RestRequest restRequest, bool resend = false)
        {
            var result = new OperationResult<string>();
            var client = new RestSharp.RestClient(firstServiceUrl);
            var response = client.Execute(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && !resend)
            {
                client = new RestSharp.RestClient(secondServiceUrl);
                response = client.Execute(restRequest);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.SetSucces(response.Content);
            }
            else
            {
                result.SetError(response);
            }

            return result;
        }

        internal static OperationResult<T> SendRequest<T>(string firstServiceUrl, string secondServiceUrl, RestRequest restRequest, bool resend = false) where T : new()
        {
            var result = new OperationResult<T>();
            var client = new RestSharp.RestClient(firstServiceUrl);
            var response = client.Execute<T>(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && !resend)
            {
                client = new RestSharp.RestClient(secondServiceUrl);
                response = client.Execute<T>(restRequest);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.SetSucces(response.Data);
            }
            else
            {
                result.SetError(response);
            }

            return result;
        }

        internal static OperationResult<string> SendRequest(string firstServiceUrl, string secondServiceUrl, RestRequest restRequest, string token, bool resend = false)
        {
            var result = new OperationResult<string>();
            var client = new RestSharp.RestClient(firstServiceUrl);
            client.AddDefaultHeader("Authorization", $"bearer {token}");
            var response = client.Execute(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && !resend)
            {
                client = new RestSharp.RestClient(secondServiceUrl);
                response = client.Execute(restRequest);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.SetSucces(response.Content);
            }
            else
            {
                result.SetError(response);
            }

            return result;
        }

        internal static OperationResult<T> SendRequest<T>(string firstServiceUrl, string secondServiceUrl, RestRequest restRequest, string token, bool resend = false) where T : new()
        {
            var result = new OperationResult<T>();
            var client = new RestSharp.RestClient(firstServiceUrl);
            client.AddDefaultHeader("Authorization", $"bearer {token}");
            var response = client.Execute<T>(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && !resend)
            {
                client = new RestSharp.RestClient(secondServiceUrl);
                response = client.Execute<T>(restRequest);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.SetSucces(response.Data);
            }
            else
            {
                result.SetError(response);
            }

            return result;
        }
    }

    internal static class OperationResultExtension
    {
        public static void SetError(this OperationResult operationResult, IRestResponse response)
        {
            operationResult.SetError(response.StatusCode.ToString(), response.Content);
        }
    }
}
