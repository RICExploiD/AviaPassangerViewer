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
            if (e.Exception is null)
            {
                Current.Shutdown();
                return;
            }

            string errorMessage = string.Format("An application error occurred. " +
                $"Error:{e.Exception.Message}\n\n" +
                "Do you want to continue?");

            if (MessageBox.Show(errorMessage, "Unhandled Error", 
                MessageBoxButton.YesNoCancel, MessageBoxImage.Error) == MessageBoxResult.No)
            {
                Current.Shutdown();
            }
        }
    }
}
