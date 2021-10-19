using NASA.BE;
using NASA.BL.Interfaces;
using NASA.DAL;
using NASA.DAL.Interfaces;
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


        #region fetch from db
        public Task<TodayPhoto> getTodayPhoto()
        {
            return IRepository.GetTodayPhoto();
        }

        public Task<List<Item>> GetLibrarySearchResult(string search)
        {
            return IRepository.GetLibrarySearchResult(search);
        }

        public Task<ObservableCollection<Planet>> getAllPlanets()
        {
            return IRepository.GetAllPlanets();
        }

        public List<Asteroid> GetAsteroidsFilteredResult(bool isDanger,double? Distance=null, DateTime? start = null, DateTime? end = null)
        {
             var list=IRepository.GetAsteroidsFilteredResult().Result;
            List<Asteroid> filterd = new();
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
                             where astroid.is_potentially_hazardous_asteroid == true
                             select astroid;
                filterd = result.ToList();
            }
            return filterd ;
        }


        #endregion
    }
}
