using _2DataAccess.Interfaces;
using _2DataAccess.Repositories;
using Model.Models;
using System;
using System.Security.Cryptography;
using System.Windows;
using System.Xml.Linq;
using WpfApp.ViewModels.Categories;

namespace WpfApp.Views.Categories
{
    /// <summary>
    /// Interaction logic for UpdateCategoryWindow.xaml
    /// </summary>
    /// 
    public partial class UpdateCategoryWindow : Window
    {        
        private readonly Category _category;
        public UpdateCategoryWindow(Category category)
        {            
            InitializeComponent();
            _category = category;
            this.DataContext = new UpdateCategoryViewModel(_category);
        }
    }
}
