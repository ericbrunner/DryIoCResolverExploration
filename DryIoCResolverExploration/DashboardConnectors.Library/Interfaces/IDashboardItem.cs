using System.ComponentModel;

namespace DashboardConnectors.Library.Interfaces;

public interface IDashboardItem : INotifyPropertyChanged
{
    string? Identifier { get; }

    string Key { get; set; }

    string? AutomationId { get; }
}