using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SysTracker.Desktop.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ViewModelBase? CurrentViewModel => NavigationStore.CurrentViewModel;
        public ViewModelBase()
        {
            NavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        protected void OnPropertyChanged([CallerMemberName] string viewModelName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(viewModelName));
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
