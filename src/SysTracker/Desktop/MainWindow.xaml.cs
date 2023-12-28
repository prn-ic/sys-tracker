using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SysTracker.Desktop.ViewModels;

namespace SysTracker.Desktop;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Close_MouseDown(object sender, MouseButtonEventArgs e) => Close();

    private void Close_MouseEnter(object sender, MouseEventArgs e)
    { 
        Cursor = Cursors.Hand;
        (sender as TextBlock)!.Foreground = new SolidColorBrush(Color.FromRgb(229, 39, 39));
    }

    private void Close_MouseLeave(object sender, MouseEventArgs e)
    {
        Cursor = Cursors.Arrow;
        (sender as TextBlock)!.Foreground = new SolidColorBrush(Color.FromRgb(91, 40, 40));
    }

    private void Main_MouseDown(object sender, MouseButtonEventArgs e) 
    {
        if (e.ChangedButton == MouseButton.Left) DragMove();
    }

    private void GithubProfile_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
        e.Handled = true;
    }

    private void OpenGeneral_Click(object sender, RoutedEventArgs e) =>
        NavigationStore.CurrentViewModel = new GeneralViewModel();

    private void OpenCpu_Click(object sender, RoutedEventArgs e) =>
        NavigationStore.CurrentViewModel = new CpuViewModel();

    private void OpenGpu_Click(object sender, RoutedEventArgs e) =>
        NavigationStore.CurrentViewModel = new GpuViewModel();

    private void OpenRam_Click(object sender, RoutedEventArgs e) =>
        NavigationStore.CurrentViewModel = new RamViewModel();

    private void OpenSystem_Click(object sender, RoutedEventArgs e) =>
        NavigationStore.CurrentViewModel = new SystemViewModel();
}
