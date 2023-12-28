using System.Reflection;

namespace SysTracker.Application.Services.TableGenerator;
public static class SmallTableDataGenerator
{
    public static List<SmallTableModel> Generate<T>(T data) where T : class
    {
        List<SmallTableModel> smallTableModels = new List<SmallTableModel>(); 
        var fields = typeof(T).GetFields(
            BindingFlags.Instance |
            BindingFlags.NonPublic |
            BindingFlags.Public | BindingFlags.Static
        );

        foreach (FieldInfo field in fields)
            smallTableModels.Add(new SmallTableModel(field, data));

        return smallTableModels;
    }
}
