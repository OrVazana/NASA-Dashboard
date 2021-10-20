using NASA.BE;
using NASA.BL.Interfaces;
using NASA.DAL;
using NASA.DAL.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
        public List<NEO> GetAsteroidsFilteredResult(bool isDanger,double Distance=-1, DateTime? start = null, DateTime? end = null)
        {
            var list=IRepository.GetAsteroidsFilteredResult().Result;
            List<NEO> filterd = new();
            if(isDanger)
            {
                var result=from astroid in list
                where astroid.is_potentially_hazardous_asteroid == true
                select astroid;
                filterd= result.ToList();
            }
            if (Distance>0)
            {
                var result = from astroid in list
                             where astroid.estimated_diameter.meters.estimated_diameter_min>=Distance
                             select astroid;
                filterd = filterd.Where(i => list.Contains(i)).ToList();
            }
            if (start!=null)
            {
                //var result = from astroid in list
                //             where astroid.
                //             select astroid;
                //filterd = result.ToList();
            }

            return filterd ;
        }
        #endregion
    }
}
