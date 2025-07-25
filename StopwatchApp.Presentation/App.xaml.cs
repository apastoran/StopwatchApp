﻿using StopwatchApp.Presentation.Composition;
using System.Windows;

namespace StopwatchApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var stopwatchView = CompositionRoot.BuildStopwatchView();
            stopwatchView.Show();
        }
    }
}
