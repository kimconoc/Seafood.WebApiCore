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
        public bool IsOpen = true;
        public ICommand SignInCommand { get; set; }
        public ICommand OpenCategoryCommand { get; set; }
        public ICommand StartTimerCommand { get; set; }
        public ICommand StopTimerCommand { get; set; }

        private readonly SignInWindow _signInWindow;
        private readonly CategoryWindow _categoryWindow;

        public MainViewModel(IAbstractFactory<SignInWindow> signInWindow, IAbstractFactory<CategoryWindow> categoryWindow)
        {
            _signInWindow = signInWindow.Create();
            _categoryWindow = categoryWindow.Create();

            SignInCommand = new RelayCommand<Window>(p =>
            {
                return true;
            }, p =>
            {
                IsOpen = false;
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

                if (signInVM.IsOpen)
                {                    
                    p.Close();
                }
                else
                {
                    IsOpen = true;
                    p.Show();
                }
            });

            OpenCategoryCommand = new RelayCommand<Window>(p =>
            {
                return true;
            }, p =>
            {
                IsOpen = false;
                p.Hide();

                _categoryWindow.ShowDialog();
                
                var categoryVM = _categoryWindow.DataContext as CategoryViewModel;
                if (categoryVM == null)
                {
                    return;
                }

                if (categoryVM.IsOpen)
                {                    
                    p.Close();
                }
                else
                {
                    IsOpen = true;
                    p.Show();
                }
            });

            StartTimerCommand = new RelayCommand<Window>(p =>
            {
                return p.IsEnabled == true;
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
