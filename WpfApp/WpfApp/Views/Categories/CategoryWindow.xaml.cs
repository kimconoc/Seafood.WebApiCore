using _2DataAccess.Interfaces;
using System.Windows;
using WpfApp.ViewModels;
using WpfApp.ViewModels.Categories;

namespace WpfApp.Views.Categories
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow(ICategoryRepository categoryRepository)
        {
            InitializeComponent();
            this.DataContext = new CategoryViewModel(categoryRepository);
        }
    }
}
