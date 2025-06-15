using System;
using System.Threading;
using StopwatchApp.Core;
using StopwatchApp.Infrastructure;
using Xunit;

namespace StopwatchApp.Tests;

public class StopwatchServiceTests
{
    //Start makes Elapsed grow and sets the Running State
    [Fact]
    public void Start_GrowsElapsed()
    {
        using var svc = new StopwatchService();

        svc.Start();
        Assert.Equal(StopwatchState.Running, svc.State);

        Thread.Sleep(120);
        var after = svc.Elapsed;
        Assert.True(after > TimeSpan.Zero);

    }

    //Pause stops the stopwatch, keeps the elapsed time and sets the Paused state.
    [Fact]
    public void Pause_StopsGrowingKeepsElapsed()
    {
        using var svc = new StopwatchService();

        svc.Start();
        Thread.Sleep(120);
        svc.Pause();

        var snapshot = svc.Elapsed;
        Thread.Sleep(120);

        Assert.Equal(StopwatchState.Paused, svc.State);
        Assert.Equal(snapshot, svc.Elapsed);
    }

    //Stop stops the stopwatch, resets the elapsed time and sets the Stopped state.
    [Fact]
    public void Stop_StopsGrowingResetsElapsed()
    {
        using var svc = new StopwatchService();

        svc.Start();
        Thread.Sleep(80);
        svc.Stop();

        Assert.Equal(StopwatchState.Stopped, svc.State);
        Assert.Equal(TimeSpan.Zero, svc.Elapsed);
    }
}