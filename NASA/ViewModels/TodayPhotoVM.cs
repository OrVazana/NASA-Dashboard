using NASA.BE;
using NASA.Models;
using NASA.Tools;

namespace NASA.ViewModels
{
    public class TodayPhotoVM : BaseVM
    {
        public TodayPhotoModel TodayPhotoModel { get; set; }

        public NotifyTaskCompletion<TodayPhoto> TodayPhoto { get; private set; }

        public TodayPhotoVM()
        {
            TodayPhotoModel = new TodayPhotoModel();

            TodayPhoto = new NotifyTaskCompletion<TodayPhoto>(TodayPhotoModel.getTodayPhoto());
        }
    }
}