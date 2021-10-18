using NASA.BE;
using NASA.BL;
using NASA.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
