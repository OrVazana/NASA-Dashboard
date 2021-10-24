using NASA.BE;
using NASA.BL.Interfaces;
using NASA.DAL;
using NASA.DAL.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASA.BL
{
    public class BLImp : IBL
    {
        public IRepository IRepository { get; set; }

        public BLImp()
        {
            IRepository = new Repository();
        }


        #region TodayPhoto
        public Task<TodayPhoto> getTodayPhoto()
        {
            return IRepository.GetTodayPhoto();
        }
        #endregion

        #region NASA Image Library + Imagga
        public List<Item> GetLibrarySearchResult(string search,bool imagga)
        {
            List<Item> ret= IRepository.GetLibrarySearchResult(search).Result;
            if (!imagga)
                return ret ;
            else
            {
                List<Item> result = Task.Run(() => imaggaApi(ret,search)).Result;
                return result;
            }
        }
        async Task<List<Item>> imaggaApi(List<Item> Items,string search)
        {
            List<Item> result = new();
            foreach (var item in Items)
            {
                if (imaggaApiReq(item.links[0].href, search))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        static bool imaggaApiReq(string imageUrl, string search)
        {
            try
            {
                string apiKey = "acc_948e876b1bfffbd";
                string apiSecret = "fe71bc85aca8b23d23ae7d77f038c538";
                string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));
                var client = new RestClient("https://api.imagga.com/v2/tags");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddParameter("image_url", imageUrl);
                request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
                IRestResponse response = client.Execute(request);

                var Tags = JsonConvert.DeserializeObject<Root>(response.Content).result.tags;
                foreach (var tag in Tags)
                {
                    if (tag.tag.en.ToLower() == search.ToLower() && tag.confidence > 40)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return true;
            }
            return false;

        }
        #endregion

        #region Solar System
        public Task<List<Planet>> getAllPlanets()
        {
            return IRepository.GetAllPlanets();
        }
        #endregion

        #region AstroidData
        public List<NEO> GetAsteroidsFilteredResult(bool isDanger, double diameter, DateTime start, DateTime end, bool reset=false)
        {
            var list=IRepository.GetAsteroidsResult().Result;
            if (reset)
            {
                return list;
            }
            else
            {
                var result = from item in list
                             where item.is_potentially_hazardous_asteroid == isDanger
                             where item.estimated_diameter.meters.estimated_diameter_min >= diameter
                             where DateTime.Parse(item.close_approach_data[0].close_approach_date).Date >= start.Date && DateTime.Parse(item.close_approach_data[0].close_approach_date).Date <= end.Date
                             select item;
                return new List<NEO>(result.ToList());
            }
        }

        public void InitDB()
        {
            IRepository.InitDB();
        }
        #endregion
    }
}
