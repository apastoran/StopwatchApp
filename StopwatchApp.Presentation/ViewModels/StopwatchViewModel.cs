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
            PauseCommand.NotifyCanExecuteChanged();
            StopCommand.NotifyCanExecuteChanged();
        }


        [RelayCommand(CanExecute = nameof(CanStart))]
        private void Start() => _svc.Start();
        private bool CanStart() => _svc.State != StopwatchState.Running;

        [RelayCommand(CanExecute = nameof(CanPause))]
        private void Pause() => _svc.Pause();
        private bool CanPause() => _svc.State == StopwatchState.Running;

        [RelayCommand(CanExecute = nameof(CanStop))]
        private void Stop() => _svc.Stop();
        private bool CanStop() => _svc.State != StopwatchState.Stopped;

    }
}
