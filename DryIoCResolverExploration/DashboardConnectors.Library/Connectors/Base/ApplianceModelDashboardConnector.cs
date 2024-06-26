using DashboardConnectors.Library.Interfaces;
using DryIoc;

namespace DashboardConnectors.Library.Connectors.Base;

public abstract class ApplianceModelDashboardConnector<TDashboardItem> : IApplianceModelDashboardConnector<TDashboardItem> where TDashboardItem : IBasePairedApplianceDashboardItem
{
    private readonly IContainer _diContainer;
    private const string DashboardConnectorLogDomain = "DashboardConnector";


    protected ApplianceModelDashboardConnector(IContainer diContainer)
    {
        _diContainer = diContainer;
    }


    public virtual TDashboardItem CreateDashboardItem()
    {
        TDashboardItem? item = default(TDashboardItem);

        var logMessage = $"for resolving: {typeof(TDashboardItem).Name}";

        try
        {
            item = _diContainer.Resolve<TDashboardItem>();

            System.Diagnostics.Debug.WriteLine(
                $"{nameof(CreateDashboardItem)} on Thread-Id:{Thread.CurrentThread.ManagedThreadId} SUCCESS in {GetType().Name} {Environment.NewLine}" + logMessage);
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(
                $"{nameof(CreateDashboardItem)} on Thread-Id:{Thread.CurrentThread.ManagedThreadId} ERROR in {GetType().Name} {Environment.NewLine}" + logMessage +
                $"{Environment.NewLine} Exception: {e}");
        }

        if (item == null)
        {
            throw new InvalidOperationException(
                $"DiContainer did not return an instance of {typeof(TDashboardItem).FullName}." +
                " Please ensure the type is added as a transient dependency to the DiContainer.");
        }

        return item;
    }
}