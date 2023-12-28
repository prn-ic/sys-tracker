using System.Collections.Generic;
using SysTracker.Application.Realizations.Windows;
using SysTracker.Core.Contracts;
using SysTracker.Desktop.Services.InfoViewer.Models;
using SysTracker.Desktop.Services.InfoViewer;

namespace SysTracker.Desktop.ViewModels;
public class RamViewModel : ViewModelBase
{
    private List<SmallTableModel> _properties;
    public List<SmallTableModel> Properties
    {
        get { return _properties; }
        set { _properties = value; OnPropertyChanged(nameof(Properties)); }
    }
    public RamViewModel()
    {
        IHardwareAdditionalInformationService hardwareAdditional = new HardwareAdditionalInformationService();
        IInfoViewer<List<SmallTableModel>> viewer = new SmallTableViewer();
        _properties = viewer.View(hardwareAdditional.GetMemoryInfo());
    }
}
