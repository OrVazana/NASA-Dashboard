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
        public ObservableCollection<Asteroid> GetAsteroidsFilteredResult()
        {
            return new ObservableCollection<Asteroid>(BL.GetAsteroidsFilteredResult().Result);
        }
    }
}
