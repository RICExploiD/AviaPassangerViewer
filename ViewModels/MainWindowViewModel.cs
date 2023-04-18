using System.Windows.Controls;

namespace AviaPassangerViewer.ViewModels
{
    using Views;
    using ViewModels.Base;

    internal sealed class MainWindowViewModel : NotifyPropertyChanged
    {
        private UserControl _displayedView;
        public UserControl DisplayedView
        {
            get => _displayedView;
            set
            {
                if (_displayedView?.Equals(value) ?? false) return;

                _displayedView = value;

                OnPropertyChanged(nameof(DisplayedView));
            }
        }
        public Command SelectPassangerViewer { get; set; }
        public Command ResetSelectedView { get; set; }
        public MainWindowViewModel()
        {
            DisplayedView = new PassangerViewer();

            SelectPassangerViewer = new(ChangeViewToPassangerViewer);
            ResetSelectedView = new(ResetView);
        }
        public void ChangeViewToPassangerViewer() { DisplayedView = new PassangerViewer(); }
        public void ResetView() { DisplayedView = null; }
    }
}
