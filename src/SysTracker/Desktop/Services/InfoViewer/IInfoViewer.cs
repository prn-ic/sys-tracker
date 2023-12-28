using SysTracker.Core.Entities;

namespace SysTracker.Desktop.Services.InfoViewer
{
    public interface IInfoViewer<T>
    {
        T View<E>(E data) where E : Hardware;
    }
}
