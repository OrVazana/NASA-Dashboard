using NASA.BE;
using System.Threading.Tasks;

namespace NASA.DAL.Interfaces
{
    public interface IRepository
    {
        public TodayPhoto GetTodayPhoto();
        Planet getSelectedPlanet(string name);
        //Task<string> GetResponseJSon(string apiUrl, string apiKey);
    }
}
