using _2DataAccess.Interfaces;
using Model.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WpfApp.ViewModels.Commons;
using WpfApp.Views.Categories;

namespace WpfApp.ViewModels.Categories
{
    public class CategoryViewModel : BaseViewModel
    {
        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories { get => _categories; set { _categories = value; OnPropertyChanged(); } }

        private Category _selectedItem;
        public Category SelectedItem { get => _selectedItem; set { _selectedItem = value; OnPropertyChanged(); } }

        public bool IsLoaded = true;
        public ICommand NewCategoryWindowCommand { get; set; }
        public ICommand UpdateCategoryPopupCommand { get; set; }
        public ICommand DeletePopupCommand { get; set; }

        public CategoryViewModel(ICategoryRepository categoryRepository)
        {
            _categories = new ObservableCollection<Category>(categoryRepository.GetAll());

            NewCategoryWindowCommand = new RelayCommand<Window>(p => { return true; }, p =>
            {
                IsLoaded = false;
                p.Hide();

                var newCategoryWindow = new NewCategoryWindow();
                newCategoryWindow.ShowDialog();

                var newCategoryVM = newCategoryWindow.DataContext as NewCategoryViewModel;
                
                if (newCategoryVM.IsSuccessed)
                {
                    var newCategory = new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = newCategoryVM.Name,
                        Description = newCategoryVM.Description,
                        Note = newCategoryVM.Note,
                        Code = newCategoryVM.Code,
                        Icon = newCategoryVM.Icon,
                        IsDeleted = newCategoryVM.IsDeleted
                    };
                    categoryRepository.Create(newCategory);
                    Categories.Add(newCategory);
                }

                if (newCategoryVM.IsLoaded)
                {
                    p.Close();                    
                }
                else
                {
                    IsLoaded = true;                    
                    p.Show();
                }
            });

            UpdateCategoryPopupCommand = new RelayCommand<object>(p => { return true; }, p =>
            {
                IsLoaded = false;  
                
                var category = p as Category;

                var updateCategoryWindow = new UpdateCategoryWindow(category);
                updateCategoryWindow.ShowDialog();

                var updateCategoryVM = updateCategoryWindow.DataContext as UpdateCategoryViewModel;                
                if (updateCategoryVM.IsSuccessed)
                {
                    var newCategory = new Category
                    {
                        Id = Guid.Parse(updateCategoryVM.Id),
                        Name = updateCategoryVM.Name,
                        Description = updateCategoryVM.Description,
                        Note = updateCategoryVM.Note,
                        Code = updateCategoryVM.Code,
                        Icon = updateCategoryVM.Icon,
                        IsDeleted = updateCategoryVM.IsDeleted,
                    };

                    categoryRepository.Update(newCategory);

                    category.Name = newCategory.Name;
                    category.Description = newCategory.Description;
                    category.Note = newCategory.Note;
                    category.Code = newCategory.Code;
                    category.Icon = newCategory.Icon;
                    category.IsDeleted = newCategory.IsDeleted;
                }
            });

            DeletePopupCommand = new RelayCommand<object>(p => { return true; }, p =>
            {
                var category = p as Category;

                var result = MessageBox.Show($"Do you want to delete Category: {category.Name}", "Category", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    categoryRepository.Delete(category);
                    Categories.Remove(category);
                }
                else if (result == MessageBoxResult.No)
                {
                    return;
                }
            });
        }
    }
}
