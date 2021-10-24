using NASA.BL;
using NASA.BL.Interfaces;

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
