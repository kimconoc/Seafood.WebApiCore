using _2DataAccess.Interfaces;
using Model.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp.Configurations;
using WpfApp.ViewModels.Commons;
using WpfApp.Views.Auth;
using WpfApp.Views.Categories;

namespace WpfApp.ViewModels.Categories
{
    public class CategoryViewModel : BaseViewModel
    {
        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories { get => _categories; set { _categories = value; OnPropertyChanged(); } }

        private Category _selectedItem;
        public Category SelectedItem { get => _selectedItem; set { _selectedItem = value; OnPropertyChanged(); } }

        public bool IsOpen = true;
        public ICommand NewCategoryWindowCommand { get; set; }
        public ICommand UpdateCategoryPopupCommand { get; set; }
        public ICommand DeletePopupCommand { get; set; }
        public ICommand StartTimerCommand { get; set; }
        public ICommand StopTimerCommand { get; set; }

        private CategoryWindow _categoryWindow;

        public CategoryViewModel(ICategoryRepository categoryRepository, IAbstractFactory<SignInWindow> signInWindow)
        {            
            _categories = new ObservableCollection<Category>(categoryRepository.GetAll());

            NewCategoryWindowCommand = new RelayCommand<Window>(p => { return true; }, p =>
            {
                IsOpen = false;
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

                if (newCategoryVM.IsOpen)
                {
                    p.Close();                    
                }
                else
                {
                    IsOpen = true;                    
                    p.ShowDialog();
                }
            });

            UpdateCategoryPopupCommand = new RelayCommand<object>(p => { return true; }, p =>
            {                
                IsOpen = false;
                
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is CategoryWindow)
                    {
                        _categoryWindow = (CategoryWindow)window;
                    }
                }
                _categoryWindow.Hide();

                var category = p as Category;

                var updateCategoryWindow = new UpdateCategoryWindow(category);
                updateCategoryWindow.ShowDialog();                

                var updateCategoryVM = updateCategoryWindow.DataContext as UpdateCategoryViewModel;                
                if (updateCategoryVM.IsSuccessed)
                {
                    IsOpen = true;

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

                    _categoryWindow.ShowDialog();
                }
                else if (!updateCategoryVM.IsOpen)
                {
                    IsOpen = true;
                    _categoryWindow.ShowDialog();
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

            StartTimerCommand = new RelayCommand<Window>(p =>
            {
                return true;
            }, p =>
            {
                TimerManager.SignInWindow = signInWindow;
                TimerManager.Instance.Start(p);
            });

            StopTimerCommand = new RelayCommand<Window>(p =>
            {
                return true;
            }, p =>
            {
                TimerManager.Instance.Stop();
            });
        }
    }
}
