using NASA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NASA.Commands
{
    public class PlanetDescriptionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SolarSystemVM CurrentVM { get; set; }

        public PlanetDescriptionCommand(SolarSystemVM VM)
        {
            CurrentVM = VM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int.TryParse(parameter.ToString(), out int Days);
            //CurrentVM.getSelectedPlanet();
        }
    }
}

