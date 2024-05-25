using DashboardConnectors.Library;
using DashboardConnectors.Library.Connectors;
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
        dryerConnector.Should().NotBeNull();
        dryerConnector.Should().NotBeNull();

    }
}