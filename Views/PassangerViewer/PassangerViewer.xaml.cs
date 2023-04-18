using System.Windows.Controls;

namespace AviaPassangerViewer.Views
{
    /// <summary>
    /// Interaction logic for PassangerViewer.xaml
    /// </summary>
    public partial class PassangerViewer : UserControl
    {
        public PassangerViewer() { _ = new PassangerViewerViewModel(this); }
    }
}
