using NASA.BL;
using NASA.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Models
{
    public class HomeModel
    {
        public IBL BL { get; set; }

        public HomeModel()
        {
            BL = new BLImp();
                
        }

        public void InitDB()
        {
            BL.InitDB();
        }
    }
}
