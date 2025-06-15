using StopwatchApp.Infrastructure;
using StopwatchApp.Presentation.ViewModels;
using StopwatchApp.Presentation.Views;
using System.Windows;

namespace StopwatchApp.Presentation.Composition
{
    public static class CompositionRoot
    {
        public static Window BuildStopwatchView()
        {
            var service = new StopwatchService();
            var vm = new StopwatchViewModel(service);
            var window = new StopwatchView()
            {
                DataContext = vm
            };
            window.Closed += (_, _) => service.Dispose();
            return window;
        }
    }
}
