using NASA.BE;
using System.Threading.Tasks;

namespace NASA.DAL.Interfaces
{
    public interface IRepository
    {
        public Task<TodayPhoto> GetTodayPhoto();
        public Task<LibrarySearch> getLibrarySearchResult();
        
        Planet getSelectedPlanet(string name);
        //Task<string> GetResponseJSon(string apiUrl, string apiKey);
    }
}
