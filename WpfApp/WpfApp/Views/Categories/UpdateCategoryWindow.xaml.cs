using _2DataAccess.Interfaces;
using _2DataAccess.Repositories;
using Model.Models;
using System;
using System.Security.Cryptography;
using System.Windows;
using System.Xml.Linq;
using WpfApp.Configurations;
using WpfApp.ViewModels.Categories;
using WpfApp.Views.Auth;

namespace WpfApp.Views.Categories
{
    /// <summary>
    /// Interaction logic for UpdateCategoryWindow.xaml
    /// </summary>
    /// 
    public partial class UpdateCategoryWindow : Window
    {        
        public UpdateCategoryWindow(Category category)
        {            
            InitializeComponent();
            this.DataContext = new UpdateCategoryViewModel(category);
        }
    }
}
