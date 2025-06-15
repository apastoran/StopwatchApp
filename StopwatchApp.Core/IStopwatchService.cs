namespace StopwatchApp.Core
{
    public enum StopwatchState { Stopped, Running, Paused }

    /// <summary>
    /// Domain abstraction representing a stopwatch.  
    /// Defines operations and data.
    /// </summary>
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
