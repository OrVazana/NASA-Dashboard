using NASA.BE;
using NASA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.ViewModels
{
    public class SolarSystemVM : BaseVM
    {
        public SolarSystemModel SolarSystemModel { get; set; }

        public Planet selectedPlanet { get; set; }

        public SolarSystemVM()
        {
            SolarSystemModel = new SolarSystemModel();
            
        }
        
        public Planet getSelectedPlanet(string name)
        {
            selectedPlanet = SolarSystemModel.getSelectedPlanet(name);
            return selectedPlanet;
        }

    }
}