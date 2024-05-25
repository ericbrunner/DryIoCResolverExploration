using DashboardConnectors.Library.Connectors.Base;
using DashboardConnectors.Library.Models;
using DryIoc;

namespace DashboardConnectors.Library.Connectors;

public class OvenDashboardConnector : ApplianceModelDashboardConnector<OvenDashboardItem>
{
    public OvenDashboardConnector(IContainer diContainer) : base(diContainer)
    {
    }
}