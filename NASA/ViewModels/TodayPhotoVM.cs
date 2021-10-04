using NASA.BE;
using NASA.Models;

namespace NASA.ViewModels
{
    public class TodayPhotoVM : BaseVM
    {
        public TodayPhotoModel TodayPhotoModel { get; set; }

        public TodayPhoto TodayPhoto { get;}

        public TodayPhotoVM()
        {
            TodayPhotoModel = new TodayPhotoModel();
            TodayPhoto = TodayPhotoModel.getTodayPhoto();
        }
    }
}