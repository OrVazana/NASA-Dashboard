using NASA.Commands;
using System.Windows.Input;

namespace NASA.ViewsModels
{
    public class MainViewModel : BaseVM
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

        public MainViewModel()
        {
            UpdateViewCommand= new UpdateViewCommand(this);
        }
    }
}
