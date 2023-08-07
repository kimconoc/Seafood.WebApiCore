using _2DataAccess.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.ViewModels.Commons;

namespace WpfApp.ViewModels.Categories
{
    public class UpdateCategoryViewModel : BaseViewModel
    {
        private string _id;
        public string Id { get => _id; set { _id = value; OnPropertyChanged(); } }

        private string _name;
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }

        private string _description;
        public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }

        private string _note;
        public string Note { get => _note; set { _note = value; OnPropertyChanged(); } }

        private string _code;
        public string Code { get => _code; set { _code = value; OnPropertyChanged(); } }

        private string _icon;
        public string Icon { get => _icon; set { _icon = value; OnPropertyChanged(); } }

        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommnad { get; set; }

        public bool IsOpen = true;
        public bool IsSuccessed = false;

        public UpdateCategoryViewModel(Category category)
        {
            _id = category.Id.ToString();
            _name = category.Name;
            _description = category.Description;
            _note = category.Note;
            _code = category.Code;
            _icon = category.Icon;
            _isDeleted = category.IsDeleted;

            SaveCommand = new RelayCommand<Window>(p =>
            {
                if (Name == null || Code == null)
                    return false;
                return true;
            }, p =>
            {                
                var resultYesNo = MessageBox.Show($"Bạn có chắc chắn muốn tạo mới category: {Name} không?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultYesNo == MessageBoxResult.Yes)
                {                                        
                    IsOpen = false;
                    IsSuccessed = true;
                    p.Hide();                    
                }
                else if (resultYesNo == MessageBoxResult.No) 
                {
                    return;
                }
            });

            CancelCommnad = new RelayCommand<Window>(p =>
            {
                return true;
            }, p =>
            {
                IsOpen = false;
                p.Hide();
            });
        }
    }
}
