using NASA.BE;
using NASA.Models;
using NASA.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NASA.ViewModels
{
    public class ImageLibrarySearchVM : BaseVM
    {
        public ImageLibrarySearchModel ImageLibrarySearchModel { get; set; }
        public ImageLibrarySearchModel CurrentM { get; set; }
        
        public NotifyTaskCompletion<List<libraryImage>> LibraryImages1 { get; set; }

        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }
        private ObservableCollection<libraryImage> libraryImages;
        public ObservableCollection<libraryImage> LibraryImages
        {
            get { return libraryImages; }
            set
            {
                libraryImages = value;
                OnPropertyChanged("LibraryImages");
                Count = libraryImages.Count;
            }
        }
        //public NotifyTaskCompletion<List<libraryImage>> libraryImages { get; set; }

        public ImageLibrarySearchVM()
        {
            ImageLibrarySearchModel = new ImageLibrarySearchModel();
        }

        async public void search(string search)
        {
            LibraryImages = new ObservableCollection<libraryImage>();
            try
            {
               LibraryImages = await Task.Run(() => ImageLibrarySearchModel.GetLibrarySearchResult(search));
            }
            catch (Exception ex)
            {
                //handle the exception
                //...............
            }
        }
    }
}
