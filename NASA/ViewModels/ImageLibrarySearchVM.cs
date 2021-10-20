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
        
        public NotifyTaskCompletion<List<Item>> LibraryImages1 { get; set; }
        
        private bool spinner;
        public bool Spinner
        {
            get { return spinner; }
            set
            {
                spinner = value;
                OnPropertyChanged("Spinner");
            }
        }
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
        private ObservableCollection<Item> libraryImages;
        public ObservableCollection<Item> LibraryImages
        {
            get { return libraryImages; }
            set
            {
                libraryImages = value;
                OnPropertyChanged("LibraryImages");
                Count = libraryImages.Count;
            }
        }
        private bool imagga=false;
        public bool Imagga
        {
            get { return imagga; }
            set
            {
                imagga = value;
                OnPropertyChanged("Imagga");
            }
        }
        public ImageLibrarySearchVM()
        {
            ImageLibrarySearchModel = new ImageLibrarySearchModel();
        }

        async public void search(string search)
        {
            Spinner = true;
            LibraryImages = new ObservableCollection<Item>();
            try
            {
               LibraryImages = await Task.Run(() => ImageLibrarySearchModel.GetLibrarySearchResult(search,imagga));
            }
            catch (Exception)
            {
                //handle the exception
                //...............
            }
            Spinner = false;
        }
    }
}
