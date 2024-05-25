using System.Windows.Input;
using DashboardConnectors.Library.Models;

namespace DashboardConnectors.Library.Interfaces;

public interface IBasePairedApplianceDashboardItem : IDashboardItem
{
    public const string FabricationNumberQueryParameterKey = "fabrication_number";

    string? FabricationNumber { get; }

    bool IsSecondDevice => false;

    string? Title { get; }

    ApplianceType ApplianceType { get; }

    string? StateDescription { get; }

    ApplianceState ApplianceState { get; }

    double Progress { get; }

    public string? NavigationPath { get; }

    public bool IsDemoAppliance { get; set; }

    public bool IsLoading { get; set; }

    public ICommand? OpenQuickActions { get; }

    public void ItemWillBeAddedToDashboard();

    public void ItemHasBeenRemovedFromDashboard();
}