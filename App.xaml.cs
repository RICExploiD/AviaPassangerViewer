using System;
using System.Windows;
using System.Windows.Threading;

namespace AviaPassangerViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Dispatcher.UnhandledException += HandleUnhandledException;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            StartupUri = new Uri("Views/MainWindow/MainWindow.xaml", UriKind.Relative);
        }
        protected void HandleUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            string errorMessage = $"An application error occurred. \nError:\n{e?.Exception.Message ?? "Exception is null"}";

            MessageBox.Show(errorMessage, "Unhandled Error");
        }
    }
}
