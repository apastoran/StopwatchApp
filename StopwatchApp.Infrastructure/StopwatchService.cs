using StopwatchApp.Core;
using System.Diagnostics;
namespace StopwatchApp.Infrastructure
{
    public class StopwatchService : IStopwatchService
    {
        private readonly Stopwatch _stopwatch = new();
        private readonly System.Timers.Timer _timer;
        public StopwatchService()
        {
            _timer = new System.Timers.Timer(100)
            {
                AutoReset = true
            };
            _timer.Elapsed += (_, _) => ElapsedChanged?.Invoke(this, _stopwatch.Elapsed);
        }
        public TimeSpan Elapsed => _stopwatch.Elapsed;
        public StopwatchState State { get; private set; } = StopwatchState.Stopped;
        public event EventHandler<TimeSpan>? ElapsedChanged;
        public void Start()
        {
            if (State == StopwatchState.Running) return;
            _stopwatch.Start();
            _timer.Start();
            State = StopwatchState.Running;
            ElapsedChanged?.Invoke(this, _stopwatch.Elapsed);
        }
        public void Pause()
        {
            if (State != StopwatchState.Running) return;
            _stopwatch.Stop();
            _timer.Stop();
            State = StopwatchState.Paused;
            ElapsedChanged?.Invoke(this, _stopwatch.Elapsed);
        }
        public void Stop()
        {
            _stopwatch.Stop();
            _stopwatch.Reset();
            _timer.Stop();
            State = StopwatchState.Stopped;
            ElapsedChanged?.Invoke(this, _stopwatch.Elapsed);
        }

    }
}
