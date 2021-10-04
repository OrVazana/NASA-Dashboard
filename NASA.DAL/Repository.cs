using System;
using System.Net.Http;
using System.Threading.Tasks;
using NASA.BE;
using NASA.DAL.Interfaces;
using Newtonsoft.Json;

namespace NASA.DAL
{
    public class Repository : IRepository
    {

        public TodayPhoto GetTodayPhoto()
        {
            string apiKey = "WsYeuuaywUAJILhko8CfVQwj38v867sG32f8QseL";
            string apodApi = "https://api.nasa.gov/planetary/apod?api_key=";
            var client = new RestSharp.RestClient("https://api.nasa.gov/");
            var request = new RestSharp.RestRequest("planetary/apod", RestSharp.Method.GET);
            request.AddParameter("api_key", "WsYeuuaywUAJILhko8CfVQwj38v867sG32f8QseL");
            var res = client.Execute(request);
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TodayPhoto myDeserializedClass = JsonConvert.DeserializeObject<TodayPhoto>(res.Content);
                return myDeserializedClass;
            }
            return null;
        }

    }
}
