using System;
using System.Threading;
using SysTracker.Application.Realizations.Windows;
using SysTracker.Core.Contracts;
using SysTracker.Core.Entities;

namespace SysTracker.Desktop.ViewModels
{
    public class GeneralViewModel : ViewModelBase, IDisposable
    {
        private readonly IHardwareInformationService _hardwareInformationService;
        private readonly Thread _updateThread;
        private Cpu _cpu = new Cpu();
        public Cpu Cpu
        {
            get { return _cpu; }
            set { _cpu = value; OnPropertyChanged(nameof(Cpu)); }
        }
        private int _cpuDiagramAngle;
        public int CpuDiagramAngle
        {
            get { return _cpuDiagramAngle; }
            set { _cpuDiagramAngle = value; OnPropertyChanged(nameof(CpuDiagramAngle)); }
        }
        private Ram _ram = new Ram();
        public Ram Ram
        {
            get { return _ram; }
            set { _ram = value; OnPropertyChanged(nameof(Ram)); }
        }
        private int _ramDiagramAngle;
        public int RamDiagramAngle
        {
            get { return _ramDiagramAngle; }
            set { _ramDiagramAngle = value; OnPropertyChanged(nameof(RamDiagramAngle)); }
        }

        public GeneralViewModel()
        {
            _hardwareInformationService = new HardwareInformationService();
            SetCpuUsage();
            SetRamUsage();

            _updateThread = new Thread(UpdateData);
            _updateThread.IsBackground = true;
            _updateThread.Start();
        }

        private int ConvertFromPercentageToAngle(int value) => (180 * value) / 100;
        private void UpdateData()
        {
            while (true)
            {
                SetCpuUsage(); 
                SetRamUsage();
                Thread.Sleep(600);
            }
        }

        private void SetCpuUsage()
        {
            Cpu = _hardwareInformationService.GetProcessorInfo();
            CpuDiagramAngle = ConvertFromPercentageToAngle(Cpu.LoadPercentage);
        }

        private void SetRamUsage()
        {
            Ram = _hardwareInformationService.GetMemoryInfo();
            Ram.Capacity = (ulong)Math.Ceiling((decimal)(Ram.Capacity / 1024));
            Ram.CurrentUsage = (ulong)Math.Ceiling((decimal)(Ram.CurrentUsage / 1024));
            int procent = (int) (100 * (Ram.Capacity - Ram.CurrentUsage)) / (int) Ram.Capacity;
            Ram.Percentage = procent;
            RamDiagramAngle = ConvertFromPercentageToAngle(procent);
        }

        public void Dispose()
        {
#pragma warning disable SYSLIB0006 // Type or member is obsolete
            _updateThread.Abort();
#pragma warning restore SYSLIB0006 // Type or member is obsolete
        }
    }
}
