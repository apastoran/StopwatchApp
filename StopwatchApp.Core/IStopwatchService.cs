namespace StopwatchApp.Core
{
    public enum StopwatchState { Stopped, Running, Paused }
    public interface IStopwatchService
    {
        TimeSpan Elapsed { get; }
        StopwatchState State { get; }

        void Start();
        void Pause();
        void Stop();
        event EventHandler<TimeSpan>? ElapsedChanged;

    }
}
