using _2DataAccess.Interfaces;
using System.Windows;
using WpfApp.Configurations;
using WpfApp.ViewModels;
using WpfApp.Views.Auth;
using WpfApp.Views.Categories;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IAbstractFactory<SignInWindow> signInWindow, IAbstractFactory<CategoryWindow> categoryWindow)
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(signInWindow, categoryWindow);
        }
    }
}
