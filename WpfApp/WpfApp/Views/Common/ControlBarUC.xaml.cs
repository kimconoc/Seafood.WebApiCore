using System.Windows.Controls;
using WpfApp.Configurations;
using WpfApp.ViewModels.Commons;
using WpfApp.Views.Auth;

namespace WpfApp.Views.Common
{
    /// <summary>
    /// Interaction logic for ControlBarUC.xaml
    /// </summary>
    public partial class ControlBarUC : UserControl
    {
        public ControlBarViewModel ControlBarViewModel { get; set; }

        public ControlBarUC()
        {
            InitializeComponent();
            this.DataContext = ControlBarViewModel = new ControlBarViewModel();
        }
    }
}
