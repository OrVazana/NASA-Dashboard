using NASA.BE;
using NASA.Models;
using NASA.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.ViewModels
{
    public class AsteroidsVM :BaseVM
    {
        public AsteroidsModel AsteroidsModel { get; set; }
        public AsteroidsModel CurrentM { get; set; }

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
        private ObservableCollection<Asteroid> asteroidData;
        public ObservableCollection<Asteroid> AsteroidData
        {
            get { return asteroidData; }
            set
            {
                asteroidData = value;
                OnPropertyChanged("AsteroidData");
                Count = asteroidData.Count;
            }
        }
        //public NotifyTaskCompletion<List<libraryImage>> libraryImages { get; set; }

        public AsteroidsVM()
        {
            AsteroidsModel = new AsteroidsModel();
            AsteroidData = new ObservableCollection<Asteroid>();
            doWork();
        }
        async public void doWork()
        {
            AsteroidData = await Task.Run(() => AsteroidsModel.GetAsteroidsFilteredResult());
        }
        //async public void search(string search)
        //{
        //    LibraryImages = new ObservableCollection<libraryImage>();
        //    try
        //    {
        //        LibraryImages = await Task.Run(() => ImageLibrarySearchModel.GetLibrarySearchResult(search));
        //    }
        //    catch (Exception ex)
        //    {
        //        //handle the exception
        //        //...............
        //    }
        //}
    }
}
