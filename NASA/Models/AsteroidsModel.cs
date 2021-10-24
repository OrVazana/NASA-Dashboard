using NASA.BE;
using NASA.BL;
using NASA.BL.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace NASA.Models
{
    public class AsteroidsModel
    {
        public IBL BL { get; set; }

        public AsteroidsModel()
        {
            BL = new BLImp();
        }
        //List<NearEarthObject>
        public ObservableCollection<NEO> GetAsteroidsFilteredResult(bool isDanger, double diameter, DateTime start, DateTime end, bool reset = false)
        {
            return new ObservableCollection<NEO>(BL.GetAsteroidsFilteredResult(isDanger, diameter, start, end, reset)); ;
        }
    }
}
