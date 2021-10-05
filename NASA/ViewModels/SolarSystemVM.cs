using NASA.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.ViewModels
{
    public class SolarSystemVM : BaseVM
    {
        public SolarSystemVM selectedPlanetModel { get; set; }

        public Planet selectedPlanet { get; }

        //public SolarSystemVM()
        //{
        //    selectedPlanetModel = new getSelectedPlanet();
        //    selectedPlanet = selectedPlanetModel.getSelectedPlanet();
        //}
    }
}