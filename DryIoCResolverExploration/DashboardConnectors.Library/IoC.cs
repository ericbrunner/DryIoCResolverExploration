using DashboardConnectors.Library.Connectors;
using DashboardConnectors.Library.Models;
using DryIoc;

namespace DashboardConnectors.Library;

public class IoC 
{
    public static readonly Container Container = new();

    public static bool IsBuilt;
    public static void BuildContainer()
    {
        if (IsBuilt) return;
        
        Container.Register<DryerDashboardItem>();
        Container.Register<WasherDashboardItem>();
        Container.Register<OvenDashboardItem>();
        
        Container.Register<DryerDashboardConnector>();
        Container.Register<WasherDashboardConnector>();
        Container.Register<OvenDashboardConnector>();

        IsBuilt = true;
    }


}