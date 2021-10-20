using NASA.BE;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NASA.DAL.Interfaces
{
    public interface IRepository
    {
        //apod api
        public Task<TodayPhoto> GetTodayPhoto();
        //library api
        public Task<List<Item>> GetLibrarySearchResult(string search);
        public Task<List<NEO>> GetAsteroidsFilteredResult();

        public Task<List<Planet>> GetAllPlanets();
        //Task<string> GetResponseJSon(string apiUrl, string apiKey);
    }
}
