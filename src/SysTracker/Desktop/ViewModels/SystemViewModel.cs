using System.Collections.Generic;
using SysTracker.Application.Realizations.Windows;
using SysTracker.Core.Contracts;
using SysTracker.Desktop.Services.InfoViewer.Models;
using SysTracker.Desktop.Services.InfoViewer;

namespace SysTracker.Desktop.ViewModels;
public class SystemViewModel : ViewModelBase
{
    private List<SmallTableModel> _properties;
    public List<SmallTableModel> Properties
    {
        get { return _properties; }
        set { _properties = value; OnPropertyChanged(nameof(Properties)); }
    }
    public SystemViewModel()
    {
        ISoftwareInformation softwareInformation = new SoftwareInformation();
        IInfoViewer<List<SmallTableModel>> viewer = new SmallTableViewer();
        _properties = viewer.View(softwareInformation.GetSystemInfo());
    }
}
