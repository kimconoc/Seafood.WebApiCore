using _2DataAccess.Interfaces;
using Model.Models;
using System.Windows;
using WpfApp.Configurations;
using WpfApp.ViewModels.Categories;
using WpfApp.Views.Auth;

namespace WpfApp.Views.Categories
{
    /// <summary>
    /// Interaction logic for NewCategoryWindow.xaml
    /// </summary>
    public partial class NewCategoryWindow : Window
    {
        public NewCategoryWindow()
        {
            InitializeComponent();
            this.DataContext = new NewCategoryViewModel();
        }
    }
}
