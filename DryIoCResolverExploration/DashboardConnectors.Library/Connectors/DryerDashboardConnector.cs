using DashboardConnectors.Library.Connectors.Base;
using DashboardConnectors.Library.Models;
using DryIoc;

namespace DashboardConnectors.Library.Connectors;

public class DryerDashboardConnector : ApplianceModelDashboardConnector<DryerDashboardItem>
{
    public DryerDashboardConnector(IContainer diContainer) : base(diContainer)
    {
    }
}