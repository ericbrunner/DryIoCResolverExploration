using DashboardConnectors.Library.Connectors;
using DashboardConnectors.Library.Models;
using DryIoc;

namespace DashboardConnectors.Library;

public class IoC
{
    public static readonly Container Container = new();

    public static void BuildContainer()
    {
        Container.Register<DryerDashboardItem>();
        Container.Register<WasherDashboardItem>();
        Container.Register<OvenDashboardItem>();
        
        Container.Register<DryerDashboardConnector>();
        Container.Register<WasherDashboardConnector>();
        Container.Register<OvenDashboardConnector>();
    }
}