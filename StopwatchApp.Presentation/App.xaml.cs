using StopwatchApp.Infrastructure;
using StopwatchApp.Presentation.ViewModels;
using System.Windows;

namespace StopwatchApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private StopwatchService? _service;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _service = new StopwatchService();

            var vm = new StopwatchViewModel(_service);

            var window = new Presentation.Views.StopwatchView
            {
                DataContext = vm
            };
            window.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _service?.Dispose();
            base.OnExit(e);
        }
    }

}
