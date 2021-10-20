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

        #region ObservableCollection<NEO> asteroidData
        private ObservableCollection<NEO> asteroidData;
        public ObservableCollection<NEO> AsteroidData
        {
            get { return asteroidData; }
            set
            {
                asteroidData = value;
                OnPropertyChanged("AsteroidData");
                Count = asteroidData.Count;
            }
        }
        #endregion

        #region isDanger
        private bool isDanger=false;
        public bool IsDanger
        {
            get { return isDanger; }
            set
            {
                isDanger = value;
                OnPropertyChanged("IsDanger");
            }
        }
        #endregion

        private double distance;
        public double Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
                if (value.Equals(string.Empty))
                    distance = -1;
            }
        }

        private string time;
        public string Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }

        public AsteroidsVM()
        {
            AsteroidsModel = new AsteroidsModel();
            AsteroidData = new ObservableCollection<NEO>();
            doWork();
        }
        async public void doWork()
        {
            Spinner = true;
            AsteroidData = await Task.Run(() => AsteroidsModel.GetAsteroidsFilteredResult(isDanger,distance));
            Spinner = false;
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
