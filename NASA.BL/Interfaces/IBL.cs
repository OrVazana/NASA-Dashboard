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
        public List<NEO> GetAsteroidsFilteredResult(bool isDanger,double Distance , DateTime? start = null, DateTime? end = null);
        public Task<List<Planet>> getAllPlanets();
    }
}
