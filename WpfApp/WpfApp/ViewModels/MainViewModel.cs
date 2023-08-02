using System.Windows;
using System.Windows.Input;
using WpfApp.ViewModels.Auth;
using WpfApp.ViewModels.Categories;
using WpfApp.ViewModels.Commons;
using WpfApp.Views.Categories;
using WpfApp.Views.Auth;
using WpfApp.Configurations;

namespace WpfApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoaded = true;
        public ICommand SignInWindowCommand { get; set; }
        public ICommand CategoryWindowCommand { get; set; }
        public ICommand MouseIdleCommand { get; set; }

        private readonly SignInWindow _signInWindow;
        private readonly CategoryWindow _categoryWindow;

        public MainViewModel(IAbstractFactory<SignInWindow> signInWindow, IAbstractFactory<CategoryWindow> categoryWindow)
        {
            _signInWindow = signInWindow.Create();
            _categoryWindow = categoryWindow.Create();

            SignInWindowCommand = new RelayCommand<Window>(p =>
            {
                return true;
            }, p =>
            {
                IsLoaded = false;
                if (p == null)
                {
                    return;
                }
                p.Hide();                
                _signInWindow.ShowDialog();
                var signInVM = _signInWindow.DataContext as SignInViewModel;

                if (signInVM == null)
                {
                    return;
                }

                if (signInVM.IsLoaded)
                {                    
                    p.Close();
                }
                else
                {
                    IsLoaded = true;
                    p.Show();
                }
            });

            CategoryWindowCommand = new RelayCommand<Window>(p =>
            {
                return true;
            }, p =>
            {
                IsLoaded = false;
                p.Hide();

                _categoryWindow.ShowDialog();

                var categoryVM = _categoryWindow.DataContext as CategoryViewModel;
                if (categoryVM == null)
                {
                    return;
                }

                if (categoryVM.IsLoaded)
                {                    
                    p.Close();
                }
                else
                {
                    IsLoaded = true;
                    p.Show();
                }
            });

            MouseIdleCommand = new RelayCommand<string>(p =>
            {
                return true;
            }, p =>
            {
                TimerManager.Instance.Execute(p);
            });            
        }
    }
}
