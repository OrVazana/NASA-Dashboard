using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NASA.BE;
using NASA.DAL.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace NASA.DAL
{
    public class Repository : IRepository
    {
        //props
        public List<Planet> planets { get; set; }
        //ctor
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
        
        //apod api
        //public TodayPhoto GetTodayPhoto()
        //{
        //    //string apiKey = "WsYeuuaywUAJILhko8CfVQwj38v867sG32f8QseL";
        //    //string apodApi = "https://api.nasa.gov/planetary/apod?api_key=";
        //    var client = new RestClient("https://api.nasa.gov/");
        //    var request = new RestRequest("planetary/apod", Method.GET);
        //    request.AddParameter("api_key", "WsYeuuaywUAJILhko8CfVQwj38v867sG32f8QseL");
        //    var res = client.Execute(request);
        //    if (res.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        TodayPhoto myDeserializedClass = JsonConvert.DeserializeObject<TodayPhoto>(res.Content);
        //        return myDeserializedClass;
        //    }
        //    return null;
        //}
        public async Task<TodayPhoto> GetTodayPhoto()
        {
            var url = "https://api.nasa.gov/planetary/apod?api_key=WsYeuuaywUAJILhko8CfVQwj38v867sG32f8QseL";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();
                    TodayPhoto myDeserializedClass = JsonConvert.DeserializeObject<TodayPhoto>(strResult);
                    return myDeserializedClass;
                }
                else
                {
                    return null;
                }
            }
        }

        //NASA Image and Video Library
        public async Task<LibrarySearch> GetLibrarySearch(string search)
        {
            var url ="https://images-api.nasa.gov"+search;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();
                    LibrarySearch myDeserializedClass = JsonConvert.DeserializeObject<LibrarySearch>(strResult);
                    return myDeserializedClass;
                }
                else
                    return null;
            }
        }
    }
}
