using _2DataAccess.Interfaces;
using System.Windows;
using WpfApp.Configurations;
using WpfApp.ViewModels.Auth;

namespace WpfApp.Views.Auth
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow(IUserRepository userRepository)
        {
            InitializeComponent();
            this.DataContext = new SignInViewModel(userRepository);
        }
    }
}
