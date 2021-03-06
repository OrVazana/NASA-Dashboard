using NASA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NASA.Commands
{
    public class UpdateViewCommand :ICommand
    {
        private MainVM viewModel;

        public UpdateViewCommand(MainVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        //solarSystem
        public void Execute(object parameter)
        {
            if (parameter.ToString() == "home")
                viewModel.SelectedViewModel = new HomeVM();
            else if (parameter.ToString() == "about")
                viewModel.SelectedViewModel = new AboutUsVM();
            else if(parameter.ToString()== "todayPhoto")
                viewModel.SelectedViewModel = new TodayPhotoVM();
            else if (parameter.ToString() == "solarSystem")
                viewModel.SelectedViewModel = new SolarSystemVM();
            else if (parameter.ToString() == "library")
                viewModel.SelectedViewModel = new ImageLibrarySearchVM();
            else if (parameter.ToString() == "asteroids")
                viewModel.SelectedViewModel = new AsteroidsVM();
        }
    }
}
