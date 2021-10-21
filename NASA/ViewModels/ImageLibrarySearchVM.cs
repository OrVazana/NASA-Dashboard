using NASA.BE;
using NASA.Commands;
using NASA.Models;
using NASA.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NASA.ViewModels
{
    public class ImageLibrarySearchVM : BaseVM
    {
        public ICommand ButtonCommand { get; set; }

        public ImageLibrarySearchModel ImageLibrarySearchModel { get; set; }
        public ImageLibrarySearchModel CurrentM { get; set; }
        
        public NotifyTaskCompletion<List<Item>> LibraryImages1 { get; set; }
        
        #region spinner
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
        #endregion

        #region count
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
        #endregion

        #region ObservableCollection<Item> libraryImages
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
        #endregion

        #region imaggaCheckBox
        private bool imagga=false;
        public bool Imagga
        {
            get { return imagga; }
            set
            {
                imagga = value;
                OnPropertyChanged(nameof(Imagga));
            }
        }
        #endregion

        #region searchText
        private string searchText;
        public string SearchText
        {
            get{ return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }
        #endregion

        #region constractor
        public ImageLibrarySearchVM()
        {
            ImageLibrarySearchModel = new ImageLibrarySearchModel();
            ButtonCommand = new RelayCommand(o => SearchButtonClick("SearchButton"));
        }
        #endregion

        #region functions

        private void SearchButtonClick(object sender) => Search();

        async private void Search()
        {
            Spinner = true;
            LibraryImages = new ObservableCollection<Item>();
            try
            {
               LibraryImages = await Task.Run(() => ImageLibrarySearchModel.GetLibrarySearchResult(SearchText,imagga));
            }
            catch (Exception)
            {
                //handle the exception
                //...............
            }
            Spinner = false;
        }
        #endregion
    }
}
