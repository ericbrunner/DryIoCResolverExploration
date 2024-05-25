using DashboardConnectors.Library;
using DashboardConnectors.Library.Connectors;
using DashboardConnectors.Library.Connectors.Base;
using DashboardConnectors.Library.Interfaces;
using DashboardConnectors.Library.Models;
using DryIoc;
using FluentAssertions;

namespace TestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        IoC.BuildContainer();
    }

    [Test]
    public void TryResolveRegistredTypes()
    {
        var dryer = IoC.Container.Resolve<DryerDashboardItem>();
        var washer = IoC.Container.Resolve<WasherDashboardItem>();
        var oven = IoC.Container.Resolve<OvenDashboardItem>();
        
        var dryerConnector = IoC.Container.Resolve<DryerDashboardConnector>();
        var washerConnecter = IoC.Container.Resolve<WasherDashboardConnector>();
        var ovenConnector=  IoC.Container.Resolve<OvenDashboardConnector>();

        dryer.Should().NotBeNull();
        washer.Should().NotBeNull();
        oven.Should().NotBeNull();
        dryerConnector.Should().NotBeNull();
        washerConnecter.Should().NotBeNull();
        ovenConnector.Should().NotBeNull();

    }


    [Test]
    public async Task TestIfRaceConditionsExistWhileIoCResolveDashboardItems()
    {
        DryerDashboardConnector? dryerConnector = IoC.Container.Resolve<DryerDashboardConnector>();
        WasherDashboardConnector? washerConnecter = IoC.Container.Resolve<WasherDashboardConnector>();
        OvenDashboardConnector? ovenConnector=  IoC.Container.Resolve<OvenDashboardConnector>();
        
        dryerConnector.Should().NotBeNull();
        washerConnecter.Should().NotBeNull();
        ovenConnector.Should().NotBeNull();


        var connectors = new List<IApplianceModelDashboardConnector<IBasePairedApplianceDashboardItem>?>
        {
            dryerConnector,
            washerConnecter,
            ovenConnector
        };

        int maxRange = 10000;
        int expectedItemsPerRun = 3;
        
        Action<int,string> log = (runIndex, identifier) => TestContext.Out.WriteLine($"Run: {runIndex} on Thread-Id:{Thread.CurrentThread.ManagedThreadId} for dashboard-item: {identifier}");
        var runTaskResults = Enumerable.Range(0, maxRange).Select(runIndex => Task.Run(() => ResolveDashboardItems(runIndex,connectors, log))).ToArray();
        
        IBasePairedApplianceDashboardItem[] allDashboardItemsofAllRuns = (await Task.WhenAll(runTaskResults)).SelectMany(t => t).ToArray();

        allDashboardItemsofAllRuns.Should().NotBeEmpty();
        allDashboardItemsofAllRuns.Length.Should().Be(maxRange * expectedItemsPerRun);
    }

    private static async Task<IBasePairedApplianceDashboardItem[]> ResolveDashboardItems(int runIndex, List<IApplianceModelDashboardConnector<IBasePairedApplianceDashboardItem>?> connectors, Action<int,string>? log = null)
    {
        Task<IBasePairedApplianceDashboardItem>[] connectorTasks = connectors.Select(connector => Task.Run(connector.CreateDashboardItem)).ToArray();

        var dashboardItems = await Task.WhenAll(connectorTasks);

        dashboardItems.Should().NotBeEmpty();
        dashboardItems.Length.Should().Be(3);
        
        foreach (var dashboardItem in dashboardItems)
        {
            log?.Invoke(runIndex, dashboardItem.Identifier);
        }

        return dashboardItems;
    }
}