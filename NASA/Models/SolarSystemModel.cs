using NASA.BE;
using NASA.BL;
using NASA.BL.Interfaces;
using System;
using System.Collections.Generic;
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
        public Planet getSelectedPlanet(string name)
        {
            return BL.getSelectedPlanet(name);
        }
    }
}
