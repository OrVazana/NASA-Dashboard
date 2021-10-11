using NASA.BE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NASA.DAL.Interfaces
{
    public interface IRepository
    {
        //apod api
        public Task<TodayPhoto> GetTodayPhoto();
        //library api
        public Task<List<libraryImage>> GetLibrarySearchResult(string search);
        
        Planet getSelectedPlanet(string name);
        //Task<string> GetResponseJSon(string apiUrl, string apiKey);
    }
}
