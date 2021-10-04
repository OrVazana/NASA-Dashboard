using NASA.Commands;
using System.Windows.Input;

namespace NASA.ViewModels
{
    public class MainVM : BaseVM
    {
        private BaseVM _selectedViewModel;
       
        public BaseVM SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainVM()
        {
            SelectedViewModel = new HomeVM();
            UpdateViewCommand= new UpdateViewCommand(this);
        }
    }
}
