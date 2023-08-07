using _2DataAccess.Interfaces;
using System.Windows;
using WpfApp.Configurations;
using WpfApp.ViewModels;
using WpfApp.ViewModels.Categories;
using WpfApp.Views.Auth;

namespace WpfApp.Views.Categories
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow(ICategoryRepository categoryRepository, IAbstractFactory<SignInWindow> signInWindow)
        {
            InitializeComponent();
            this.DataContext = new CategoryViewModel(categoryRepository, signInWindow);
        }
    }
}
