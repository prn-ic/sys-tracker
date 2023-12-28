using System.Collections.Generic;
using SysTracker.Application.Realizations.Windows;
using SysTracker.Core.Contracts;
using SysTracker.Desktop.Services.InfoViewer;
using SysTracker.Desktop.Services.InfoViewer.Models;

namespace SysTracker.Desktop.ViewModels;
public class CpuViewModel : ViewModelBase
{
    private List<SmallTableModel> _properties;
    public List<SmallTableModel> Properties
    {
        get { return _properties; }
        set { _properties = value; OnPropertyChanged(nameof(Properties)); }
    }
    public CpuViewModel()
    {
        IHardwareAdditionalInformationService hardwareAdditional = new HardwareAdditionalInformationService();
        IInfoViewer<List<SmallTableModel>> viewer = new SmallTableViewer();
        _properties = viewer.View(hardwareAdditional.GetProcessorInfo());
    }
}
