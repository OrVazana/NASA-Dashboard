using NASA.BE;
using NASA.Commands;
using NASA.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace NASA.ViewModels
{
    public class AsteroidsVM :BaseVM
    {
        public ICommand FilterButtonCommand { get; set; }
        public ICommand ResetButtonCommand { get; set; }

        public AsteroidsModel AsteroidsModel { get; set; }

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
        
        #region diameter
        private double diameter;
        public double Diameter
        {
            get { return diameter; }
            set
            {
                //if (value.Equals(string.Empty))
                //    diameter =0;
                //else
                diameter = value;
                OnPropertyChanged("diameter");
            }
        }
        #endregion

        #region startDate
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (validateDate(value) && (value <= EndDate))
                {
                    startDate = value;
                }
                else
                {
                    startDate = DateTime.Today.AddDays(-7);
                }
                OnPropertyChanged(nameof(StartDate));
            }
        }
        #endregion

        #region endDate
        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (validateDate(value) && value >= startDate)
                {
                    endDate = value; 
                }
                else
                {
                    endDate = DateTime.Today;
                }
                OnPropertyChanged(nameof(EndDate));

            }
        }
        #endregion

        private DateTime displayDateStart = DateTime.Today.AddDays(-7);
        public DateTime DisplayDateStart
        {
            get { return displayDateStart; }
        }

        private DateTime displayDateEnd = DateTime.Today;
        public DateTime DisplayDateEnd
        {
            get { return displayDateEnd; }
        }

        public AsteroidsVM()
        {
            AsteroidsModel = new AsteroidsModel();
            AsteroidData = new ObservableCollection<NEO>();
            reset();
            FilterButtonCommand = new RelayCommand(o => FilterButtonClick("FilterButton"));
            ResetButtonCommand = new RelayCommand(o => ResetButtonClick("ResetButton"));

        }
        #region Command Click Functions
        private void FilterButtonClick(string v)
        {
            Filter();
        }

        private void ResetButtonClick(string v)
        {
            reset();
        }
        #endregion

        async public void Filter()
        {
            Spinner = true;
            AsteroidData = await Task.Run(() => AsteroidsModel.GetAsteroidsFilteredResult(IsDanger,diameter,StartDate,EndDate));
            Spinner = false;
        }
        async public void reset()
        {
            StartDate = DateTime.Now.AddDays(-7);
            EndDate = DateTime.Now;
            Diameter = 0;
            IsDanger = false;
            Spinner = true;
            AsteroidData = await Task.Run(() => AsteroidsModel.GetAsteroidsFilteredResult(IsDanger, diameter, StartDate, EndDate,true));
            Spinner = false;
        }

        public bool validateDate(DateTime value) => value <= DateTime.Today && value >= DateTime.Today.AddDays(-7);
    }
}
