using System.Windows.Controls;

namespace AviaPassangerViewer.Views
{
    /// <summary>
    /// Interaction logic for PassangerViewer.xaml
    /// </summary>
    public partial class PassangerViewer : UserControl
    {
        private PassangerViewerViewModel _viewModel;
        public PassangerViewer() 
        {
            InitializeComponent();
            
            _viewModel = new PassangerViewerViewModel(); 

            DataContext = _viewModel;
        }
    }
}
