using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NASA.BE;
using NASA.DAL.Interfaces;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;

namespace NASA.DAL
{
    public class Repository : IRepository
    {
        #region init
        //private bool flag = false;
        public Repository()
        {
            //if (!flag)
            //{
            //    List<Planet> Planets = new List<Planet>();
            //    Planets.Add(new Planet() { Name = "Earth", ImageSource = "/Images/Earth.png", Description = "Earth is the third planet from the Sun and the only astronomical object known to harbour and support life. About 29.2% of Earth's surface is land consisting of continents and islands. The remaining 70.8% is covered with water." });
            //    Planets.Add(new Planet() { Name = "Mars", ImageSource = "/Images/mars.png", Description = "Mars is the fourth planet from the Sun and the second-smallest planet in the Solar System, being larger than only Mercury. In English, Mars carries the name of the Roman god of war and is often referred to as the Red Planet" });
            //    Planets.Add(new Planet() { Name = "Jupiter", ImageSource = "/Images/Jupiter.png", Description = "Jupiter is the fifth planet from the Sun and the largest in the Solar System. It is a gas giant with a mass more than two and a half times that of all the other planets in the Solar System combined, but slightly less than one-thousandth the mass of the Sun." });
            //    Planets.Add(new Planet() { Name = "Saturn", ImageSource = "/Images/saturn.png", Description = "Saturn is the sixth planet from the Sun and the second-largest in the Solar System, after Jupiter. It is a gas giant with an average radius of about nine and a half times that of Earth. It only has one-eighth the average density of Earth; however, with its larger volume, Saturn is over 95 times more massive." });
            //    Planets.Add(new Planet() { Name = "Uranus", ImageSource = "/Images/URANUS.png", Description = "Uranus is the seventh planet from the Sun. Its name is a reference to the Greek god of the sky, Uranus, who, according to Greek mythology, was the great-grandfather of Ares (Mars), grandfather of Zeus (Jupiter) and father of Cronus (Saturn)." });
            //    Planets.Add(new Planet() { Name = "Neptune", ImageSource = "/Images/NEPTUNE.png", Description = "Neptune is the eighth and farthest known Solar planet from the Sun. In the Solar System, it is the fourth-largest planet by diameter, the third-most-massive planet, and the densest giant planet. It is 17 times the mass of Earth, slightly more massive than its near-twin Uranus." });
            //    Planets.Add(new Planet() { Name = "Mercury", ImageSource = "/Images/Mercury.png", Description = "Mercury is the smallest planet in the Solar System and the closest to the Sun. Its orbit around the Sun takes 87.97 Earth days, the shortest of all the Sun's planets. It is named after the Roman god Mercurius (Mercury), god of commerce" });
            //    Planets.Add(new Planet() { Name = "Venus", ImageSource = "/Images/Venus_new.png", Description = "Venus is the second planet from the Sun. It is named after the Roman goddess of love and beauty. As the brightest natural object in Earth's night sky after the Moon, Venus can cast shadows and can be, on rare occasions, visible to the naked eye in broad daylight." });
            //    foreach (var item in Planets)
            //    {
            //        AddPlanet(item);
            //    }
            //    flag = true;
            //}
        }
        
        public void InitDB()
        {
            var context = new DB();
            context.Planets.ToList();
        }
        #endregion

        #region SolarSystem
        public async void AddPlanet(Planet p)
        {
            await using (var context = new DB())
            {
                
                context.Planets.Add(p);
                context.SaveChanges();
            }
        }

        public async Task<List<Planet>> GetAllPlanets()
        {
            await using (var context = new DB())
            {
                return context.Planets.ToList();
            }
        }
        #endregion

        #region Apod - Astronomy Picture of the Day
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
        #endregion

        #region Image and Video Library
        public async Task<List<Item>> GetLibrarySearchResult(string search)
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
                    List<Item> items = new List<Item>();
                    return myDeserializedClass.collection.items;
                }
                else
                    return null;
            }
        }
        #endregion
        
        #region Astroids neo-ws
        public async Task<List<NEO>> GetAsteroidsResult()
        {
            DateTime endDate = DateTime.Today;
            DateTime startDate = DateTime.Today.AddDays(-7);
            string end_date = endDate.ToString("yyyy-MM-dd");
            string start_date= startDate.ToString("yyyy-MM-dd");
            string apiKey = "WsYeuuaywUAJILhko8CfVQwj38v867sG32f8QseL";
            //Neo - Feed - "https://api.nasa.gov/neo/rest/v1/feed?start_date="+start_date+"&end_date="+end_date+"&api_key="+apiKey;
            var url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + start_date + "&end_date=" + end_date + "&api_key="+apiKey;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();
                    AsteroidRoot myDeserializedClass = JsonConvert.DeserializeObject<AsteroidRoot>(strResult);
                    List<NEO> items = new List<NEO>();
                    foreach (var listNeo in myDeserializedClass.near_earth_objects)
                    {
                        foreach (var item in listNeo.Value)
                        {
                            items.Add(item);
                        }
                    }
                    return items;
                }
                else
                    return null;
            }
        }

       
        #endregion
    }
}
