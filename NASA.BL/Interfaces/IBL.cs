using NASA.BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.BL.Interfaces
{
    public interface IBL
    {
        public Task<TodayPhoto> getTodayPhoto();
        public List<Item> GetLibrarySearchResult(string search,bool imagga);
        public List<NEO> GetAsteroidsFilteredResult(bool isDanger,double diameter, DateTime start, DateTime end,bool reset=false);
        void InitDB();
        public Task<List<Planet>> getAllPlanets();
    }
}
