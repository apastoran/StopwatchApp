using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StopwatchApp.Core;
using System.Windows;

namespace StopwatchApp.Presentation.ViewModels
{
    public partial class StopwatchViewModel : ObservableObject
    {
        private readonly IStopwatchService _svc;

        [ObservableProperty]
        private TimeSpan elapsed;

        public string Time => Elapsed.ToString(@"hh\:mm\:ss");
        public StopwatchViewModel(IStopwatchService svc)
        {
            _svc = svc;
            _svc.ElapsedChanged += (_, span) => Application.Current.Dispatcher.InvokeAsync(() => Elapsed = span, System.Windows.Threading.DispatcherPriority.Normal);
        }


        partial void OnElapsedChanged(TimeSpan oldValue, TimeSpan newValue)
        {
            OnPropertyChanged(nameof(Time));
            StartCommand.NotifyCanExecuteChanged();
        }


        [RelayCommand(CanExecute = nameof(CanStart))]
        private void Start() => _svc.Start();
        private bool CanStart() => _svc.State != StopwatchState.Running;

    }
}
