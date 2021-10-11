using NASA.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.BL.Interfaces
{
    public interface IBL
    {
        public Task<TodayPhoto> getTodayPhoto();
        public Task<List<libraryImage>> GetLibrarySearchResult(string search);
        public Planet getSelectedPlanet(string name);
    }
}
