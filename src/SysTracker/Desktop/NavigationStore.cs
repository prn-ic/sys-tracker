using System;
using SysTracker.Desktop.ViewModels;

namespace SysTracker.Desktop
{
    public static class NavigationStore
    {
        public static event Action? CurrentViewModelChanged;
        private static ViewModelBase? _currentViewModel;
        public static ViewModelBase? CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private static void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
