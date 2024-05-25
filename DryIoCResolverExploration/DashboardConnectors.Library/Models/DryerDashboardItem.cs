using System.ComponentModel;
using System.Windows.Input;
using DashboardConnectors.Library.Interfaces;

namespace DashboardConnectors.Library.Models;

public class DryerDashboardItem : IBasePairedApplianceDashboardItem
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public string? Identifier => nameof(DryerDashboardItem);
    public string Key { get; set; }
    public string? AutomationId { get; }
    public string? FabricationNumber { get; }
    public string? Title { get; }
    public ApplianceType ApplianceType { get; }
    public string? StateDescription { get; }
    public ApplianceState ApplianceState { get; }
    public double Progress { get; }
    public string? NavigationPath { get; }
    public bool IsDemoAppliance { get; set; }
    public bool IsLoading { get; set; }
    public ICommand? OpenQuickActions { get; }

    public void ItemWillBeAddedToDashboard()
    {

    }

    public void ItemHasBeenRemovedFromDashboard()
    {

    }
}