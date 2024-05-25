using DashboardConnectors.Library;

namespace MauiApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        IoC.BuildContainer();
        
        MainPage = new AppShell();
    }
}