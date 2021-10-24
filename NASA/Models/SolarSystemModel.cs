using NASA.BE;
using NASA.BL;
using NASA.BL.Interfaces;
using System.Collections.ObjectModel;

namespace NASA.Models
{
    public class SolarSystemModel
    {
        public IBL BL { get; set; }

        public SolarSystemModel()
        {
            BL = new BLImp();
        }
        public ObservableCollection<Planet> getAllPlanets()
        {
            return new ObservableCollection<Planet>(BL.getAllPlanets().Result);
        }
    }
}
