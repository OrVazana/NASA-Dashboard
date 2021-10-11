using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Reflection;
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
            //
            planets = new List<Planet> { 
            new Planet() {id=1, Name= "EarthPlanet",Description= "Earth is the third planet from the Sun and the only astronomical object known to harbour and support life. About 29.2% of Earth's surface is land consisting of continents and islands. The remaining 70.8% is covered with water"},
            new Planet() {id=2, Name= "MarsPlanet",Description= "Mars is the fourth planet from the Sun and the second-smallest planet in the Solar System, being larger than only Mercury. In English, Mars carries the name of the Roman god of war and is often referred to as the Red Planet"},
            new Planet() {id=3, Name= "JupiterPlanet",Description= "Jupiter is the fifth planet from the Sun and the largest in the Solar System. It is a gas giant with a mass more than two and a half times that of all the other planets in the Solar System combined, but slightly less than one-thousandth the mass of the Sun."},
            new Planet() {id=4, Name= "SaturnPlanet",Description= "Saturn is the sixth planet from the Sun and the second-largest in the Solar System, after Jupiter. It is a gas giant with an average radius of about nine and a half times that of Earth. It only has one-eighth the average density of Earth; however, with its larger volume, Saturn is over 95 times more massive."},
            new Planet() {id=5, Name= "UranusPlanet",Description= "Uranus is the seventh planet from the Sun. Its name is a reference to the Greek god of the sky, Uranus, who, according to Greek mythology, was the great-grandfather of Ares (Mars), grandfather of Zeus (Jupiter) and father of Cronus (Saturn)."},
            new Planet() {id=6, Name= "NeptunePlanet",Description= "Neptune is the eighth and farthest known Solar planet from the Sun. In the Solar System, it is the fourth-largest planet by diameter, the third-most-massive planet, and the densest giant planet. It is 17 times the mass of Earth, slightly more massive than its near-twin Uranus."},
            new Planet() {id=7, Name= "MercuryPlanet",Description= "Mercury is the smallest planet in the Solar System and the closest to the Sun. Its orbit around the Sun takes 87.97 Earth days, the shortest of all the Sun's planets. It is named after the Roman god Mercurius (Mercury), god of commerce"},
            new Planet() {id=8, Name= "VenusPlanet",Description= "Venus is the second planet from the Sun. It is named after the Roman goddess of love and beauty. As the brightest natural object in Earth's night sky after the Moon, Venus can cast shadows and can be, on rare occasions, visible to the naked eye in broad daylight."}
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
        public async Task<List<libraryImage>> GetLibrarySearchResult(string search)
        {
            var url = "https://images-api.nasa.gov/search?media_type=image&q=" + search;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();
                    LibrarySearch myDeserializedClass = JsonConvert.DeserializeObject<LibrarySearch>(strResult);
                    List<libraryImage> items = new List<libraryImage>();
                    foreach (var item in myDeserializedClass.collection.items)
                    {
                        items.Add(new libraryImage(item.links[0].href, item.data[0].title, item.data[0].description));
                        Trace.WriteLine(item.data[0].title);
                    }
                    return items;
                }
                else
                    return null;
            }
        }

        //Astroids
        public async Task<List<Asteroid>> GetAsteroidsFilteredResult()
        {
            var url = "https://api.nasa.gov/neo/rest/v1/neo/browse?api_key=WsYeuuaywUAJILhko8CfVQwj38v867sG32f8QseL";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();
                    AsteroidsRoot myDeserializedClass = JsonConvert.DeserializeObject<AsteroidsRoot>(strResult);
                    List<Asteroid> items = new List<Asteroid>();
                    foreach (var item in myDeserializedClass.near_earth_objects)
                    {
                        items.Add(new Asteroid(item.id,item.name,item.absolute_magnitude_h, item.designation,item.is_potentially_hazardous_asteroid,item.estimated_diameter.kilometers));
                    }
                    return items;
                }
                else
                    return null;
            }
        }
    }
}
