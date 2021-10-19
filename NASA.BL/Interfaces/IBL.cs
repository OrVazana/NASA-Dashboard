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
        public Task<List<Item>> GetLibrarySearchResult(string search);
        public List<Asteroid> GetAsteroidsFilteredResult(bool isDanger,double? Distance = null, DateTime? start = null, DateTime? end = null);
        public Task<ObservableCollection<Planet>> getAllPlanets();
    }
}
