using System;
using System.Net;

namespace MessageApp.Console.Model
{
    public class Sender : ISender
    {
        private readonly string _serviceUrl;
        private readonly string _apiKey;

        public Sender(string serviceUrl, string apiKey)
        {
            _serviceUrl = serviceUrl;
            _apiKey = apiKey;
        }
        /// <summary>
        /// Posts message and date to server
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>Status code of the request</returns>
        public HttpStatusCode Post(string message)
        {
            var httpClient = new EasyHttp.Http.HttpClient();
            //Restricting posts to server
            httpClient.Request.AddExtraHeader("X-API-KEY", _apiKey);

            var response = httpClient.Post(_serviceUrl, new
            {
                TextMessage = message,
                DateTime = DateTime.Now
            }, "application/json");

            return response.StatusCode;
        }
    }
}
