using System.Windows;
using SysTracker.Desktop.ViewModels;

namespace SysTracker.Desktop;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        NavigationStore.CurrentViewModel = new GeneralViewModel();
        MainWindow = new MainWindow()
        {
            DataContext = new GeneralViewModel()
        };

        MainWindow.Show();

        base.OnStartup(e);
    }
}
