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
            _stopwatch.Start();
            _timer.Start();
            State = StopwatchState.Running;
        }
        public void Pause() { }
        public void Stop() { }

    }
}
