using ArnabDeveloper.HtmlContent.Core.Services;
using System.Windows;

namespace ArnabDeveloper.HtmlContent.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow? _window;

        protected override void OnStartup(StartupEventArgs e)
        {
            IHtmlContentService htmlContentService = new HtmlContentService();
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
}
