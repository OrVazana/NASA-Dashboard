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
    public class AsteroidsModel
    {
        public IBL BL { get; set; }

        public AsteroidsModel()
        {
            BL = new BLImp();
        }
        //List<NearEarthObject>
        public ObservableCollection<Asteroid> GetAsteroidsFilteredResult(bool isDanger, double? Distance = null, DateTime? start = null, DateTime? end = null)
        {
            return new ObservableCollection<Asteroid>(BL.GetAsteroidsFilteredResult(isDanger,Distance,start,end));
        }
    }
}
