using NASA.BE;
using NASA.BL;
using NASA.BL.Interfaces;
using System.Collections.ObjectModel;

namespace NASA.Models
{
    public class ImageLibrarySearchModel 
    {
        public IBL BL { get; set; }

        public ImageLibrarySearchModel()
        {
            BL = new BLImp();
        }
        public ObservableCollection<Item> GetLibrarySearchResult(string search,bool imagga)
        {
            return new ObservableCollection<Item>(BL.GetLibrarySearchResult(search,imagga));
        }
    }
}
