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
            //
            var planets = new List<Planet> { 
            new Planet() {id=1, Name= "EarthPlanet",Description= "Earth is the third planet from the Sun and the only astronomical object known to harbour and support life. About 29.2% of Earth's surface is land consisting of continents and islands. The remaining 70.8% is covered with water"},
            new Planet() {id=2,Name= "MarsPlanet",Description= "Mars is the fourth planet from the Sun and the second-smallest planet in the Solar System, being larger than only Mercury. In English, Mars carries the name of the Roman god of war and is often referred to as the Red Planet"},
            new Planet() {id=3,Name= "JupiterPlanet",Description= "Jupiter is the fifth planet from the Sun and the largest in the Solar System. It is a gas giant with a mass more than two and a half times that of all the other planets in the Solar System combined, but slightly less than one-thousandth the mass of the Sun."},
            new Planet() {id=4,Name= "SaturnPlanet ",Description= "Saturn is the sixth planet from the Sun and the second-largest in the Solar System, after Jupiter. It is a gas giant with an average radius of about nine and a half times that of Earth. It only has one-eighth the average density of Earth; however, with its larger volume, Saturn is over 95 times more massive."},
            new Planet() {id=5,Name= "UranusPlanet",Description= "Uranus is the seventh planet from the Sun. Its name is a reference to the Greek god of the sky, Uranus, who, according to Greek mythology, was the great-grandfather of Ares (Mars), grandfather of Zeus (Jupiter) and father of Cronus (Saturn)."},
            new Planet() {id=6,Name= "NeptunePlanet",Description= "Neptune is the eighth and farthest known Solar planet from the Sun. In the Solar System, it is the fourth-largest planet by diameter, the third-most-massive planet, and the densest giant planet. It is 17 times the mass of Earth, slightly more massive than its near-twin Uranus."},
            new Planet() {id=7,Name= "MercuryPlanet",Description= "Mercury is the smallest planet in the Solar System and the closest to the Sun. Its orbit around the Sun takes 87.97 Earth days, the shortest of all the Sun's planets. It is named after the Roman god Mercurius (Mercury), god of commerce"},
            new Planet() {id=8,Name= "VenusPlanet",Description= "Venus is the second planet from the Sun. It is named after the Roman goddess of love and beauty. As the brightest natural object in Earth's night sky after the Moon, Venus can cast shadows and can be, on rare occasions, visible to the naked eye in broad daylight."}
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
