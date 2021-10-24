using NASA.BE;
using NASA.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NASA.ViewModels
{
    public class SolarSystemVM : BaseVM
    {
        public SolarSystemModel SolarSystemModel { get; set; }

        private ObservableCollection<Planet> _planets;
        public ObservableCollection<Planet> Planets
        {
            get
            {
                return _planets;
            }
            set
            {
                _planets = value;
                OnPropertyChanged("Planets");
            }
        }

        private Planet _selectedPlanet;
        public Planet SelectedPlanet
        {
            get
            {
                return _selectedPlanet;
            }
            set
            {
                _selectedPlanet = value;
                OnPropertyChanged("SelectedPlanet");
            }
        }
        public SolarSystemVM()
        {
            SolarSystemModel = new SolarSystemModel();
            getAllPlanets();
        }

        async public void getAllPlanets()
        {
            Planets = await Task.Run(() => SolarSystemModel.getAllPlanets());
            SelectedPlanet = Planets[0];
        }

    }
}