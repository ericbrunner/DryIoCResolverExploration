using DashboardConnectors.Library.Interfaces;

namespace DashboardConnectors.Library.Connectors.Base;

public interface IApplianceModelDashboardConnector<out TDashboardItem> where TDashboardItem : IBasePairedApplianceDashboardItem
{
    TDashboardItem CreateDashboardItem();
}