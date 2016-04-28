using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

            var response = httpClient.Post(_serviceUrl, new
            {
                ApiKey = _apiKey, //Restricting posts to server
                Message = message,
                DateTime = DateTime.Now
            }, "application/json");

            return response.StatusCode;
        }
    }
}
