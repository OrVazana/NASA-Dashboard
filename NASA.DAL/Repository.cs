using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NASA.BE;
using NASA.DAL.Interfaces;
using Newtonsoft.Json;

namespace NASA.DAL
{
    public class Repository : IRepository
    {
        public List<Planet> planets { get; set; }
        public Repository()
        {
            var planets = new List<Planet> { 
            new Planet() {id=1,Name= "mercuriy",Description= "mercuriy big planet" },
            new Planet() {id=2,Name= "mars",Description= "mars big planet"},
            new Planet() {id=3,Name= "earth",Description= "earth big planet"},
            new Planet() {id=4,Name= "mars",Description= "mars big planet"},
            new Planet() {id=5,Name= "seturan",Description= "seturan big planet"},
            new Planet() {id=6,Name= "jupiter",Description= "jupiter big planet"},
            new Planet() {id=7,Name= "aurenus",Description= "aurenus big planet"},
            new Planet() {id=8,Name= "nepton",Description= "nepton big planet"}
            };


        }
        public Planet getSelectedPlanet(string name)
        {         
            foreach (var item in planets)
            {
                if (name == item.Name)
                    return item;
            }
            return planets[0];
        }

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
