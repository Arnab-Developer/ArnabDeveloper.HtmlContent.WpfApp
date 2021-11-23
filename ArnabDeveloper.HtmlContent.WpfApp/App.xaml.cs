using ArnabDeveloper.HtmlContent.Core.Services;
using ArnabDeveloper.HttpHealthCheck.DI;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace ArnabDeveloper.HtmlContent.WpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private MainWindow? _window;

    protected override void OnStartup(StartupEventArgs e)
    {
        IServiceCollection services = new ServiceCollection();
        services.AddHtmlContentService();
        IServiceProvider serviceProvider = services.BuildServiceProvider();
        IHtmlContentService htmlContentService = serviceProvider.GetRequiredService<IHtmlContentService>();
        _window = new(htmlContentService);
        _window.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        if (_window != null)
        {
            _window.Close();
        }
    }
}