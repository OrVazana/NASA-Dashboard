using System.ComponentModel;

namespace NASA.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)    
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
