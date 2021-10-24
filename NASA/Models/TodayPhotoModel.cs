using NASA.BE;
using NASA.BL;
using NASA.BL.Interfaces;
using System.Threading.Tasks;

namespace NASA.Models
{
    public class TodayPhotoModel
    {
        public IBL BL { get; set; }

        public TodayPhotoModel()
        {
            BL = new BLImp();
        }
        public Task<TodayPhoto> getTodayPhoto()
        {
            return BL.getTodayPhoto();
        }
    }
}
