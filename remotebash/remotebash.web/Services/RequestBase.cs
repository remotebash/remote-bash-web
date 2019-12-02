using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using remotebash.web.Models;
using remotebash.web.Services.Interface;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace remotebash.web.Services
{
    public class RequestBase<T> : IRequestBase<T>
    {

        private readonly string urlBase;
        public RequestBase(IConfiguration config)
        {
            urlBase = config.GetSection("restApi:prd").Value;
        }

        public T SendDeleteAsync(string uri, T model)
        {
            throw new NotImplementedException();
        }

        public List<T> SendGetAll(string uri)
        {
            var client = new RestClient(urlBase);
            var request = new RestRequest(uri, Method.GET);

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var response = client.Execute(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<T> model = JsonConvert.DeserializeObject<List<T>>(response.Content);
                return model;
            }

            return null;
        }

        public T SendGet(string uri)
        {
            var client = new RestClient(urlBase);
            var request = new RestRequest(uri, Method.GET);

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                T model = JsonConvert.DeserializeObject<T>(response.Content);
                return model;
            }

            return JsonConvert.DeserializeObject<T>("");
        }

        public T SendGetPathVariableAsync(string uri, string path)
        {
            var client = new RestClient(urlBase);
            var request = new RestRequest(uri, Method.GET);

            request.Resource = $"{uri}{path}";

            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                T model = JsonConvert.DeserializeObject<T>(response.Content);
                return model;
            }

            return JsonConvert.DeserializeObject<T>("");
        }

        public T SendPostAsync(string uri, T model)
        {
            string json = JsonConvert.SerializeObject(model);
            var client = new RestClient(urlBase);
            var request = new RestRequest(Method.POST);

            request.Resource = uri;
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                T modelResponse = JsonConvert.DeserializeObject<T>(response.Content);
                return modelResponse;
            }

            return JsonConvert.DeserializeObject<T>("");
        }

        public string SendPostReturnStringAsync(string uri, T model)
        {
            string json = JsonConvert.SerializeObject(model);
            var client = new RestClient(urlBase);
            var request = new RestRequest(Method.POST);

            request.Resource = uri;
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Content;

            return "";
        }

        public T SendPutAsync(string uri, T model)
        {
            throw new NotImplementedException();
        }

    }
}
