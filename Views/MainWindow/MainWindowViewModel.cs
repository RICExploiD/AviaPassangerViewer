﻿using System.Windows.Controls;

namespace AviaPassangerViewer.Views
{
    using MVVM.Base;
    internal sealed class MainWindowViewModel : NotifyPropertyChanged
    {
        private readonly MainWindow _view;
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
        public Command SelectPassangerViewer { get; set; } = new();
        public Command ResetSelectedView { get; set; } = new();
        public MainWindowViewModel(MainWindow view)
        {
            _view = view;
            _view.InitializeComponent();
            _view.DataContext = this;

            SelectPassangerViewer.ExecutableAction += _ => ChangeViewToPassangerViewer();
            ResetSelectedView.ExecutableAction += _ => ResetView();
        }
        public void ChangeViewToPassangerViewer() { DisplayedView = new PassangerViewer(); }
        public void ResetView() { DisplayedView = null; }
    }
}