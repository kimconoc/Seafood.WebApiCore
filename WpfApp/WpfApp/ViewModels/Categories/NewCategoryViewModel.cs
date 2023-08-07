using _2DataAccess.Interfaces;
using Model.Models;
using System.Windows;
using System.Windows.Input;
using WpfApp.ViewModels.Commons;

namespace WpfApp.ViewModels.Categories
{
    public class NewCategoryViewModel : BaseViewModel
    {
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

        public NewCategoryViewModel()
        {
            SaveCommand = new RelayCommand<Window>(p =>
            {
                if (Name == null || Code == null)
                    return false;
                return true;
            }, p =>
            {                
                var resultYesNo = MessageBox.Show("Bạn có chắc chắn muốn tạo mới category này không?" + Name, "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultYesNo == MessageBoxResult.Yes)
                {                                        
                    IsOpen = false;
                    IsSuccessed = true;
                    p.Hide();                                       
                }
                else
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
