using System.Windows;

namespace AviaPassangerViewer.Views
{
    using ViewModels;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            
            _viewModel = new MainWindowViewModel(); 

            DataContext = _viewModel;
        }
    }
}
