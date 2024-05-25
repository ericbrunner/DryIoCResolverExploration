using DashboardConnectors.Library.Connectors.Base;
using DashboardConnectors.Library.Models;
using DryIoc;

namespace DashboardConnectors.Library.Connectors;

public class WasherDashboardConnector : ApplianceModelDashboardConnector<WasherDashboardItem>
{
    public WasherDashboardConnector(IContainer diContainer) : base(diContainer)
    {
    }
}