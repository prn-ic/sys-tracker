using System.Collections.Generic;
using SysTracker.Application.Realizations.Windows;
using SysTracker.Application.Services.TableGenerator;
using SysTracker.Core.Contracts;

namespace SysTracker.Desktop.ViewModels;
public class CpuViewModel : ViewModelBase
{
    private readonly IHardwareInformationService _hardwareInformationService;
    private List<SmallTableModel> _properties;
    public List<SmallTableModel> Properties
    {
        get { return _properties; }
        set { _properties = value; OnPropertyChanged(nameof(Properties)); }
    }
    public CpuViewModel()
    {
        _hardwareInformationService = new HardwareInformationService();
        _properties = SmallTableDataGenerator.Generate(_hardwareInformationService.GetProcessorInfo());
    }
}
