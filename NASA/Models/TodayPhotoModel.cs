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
