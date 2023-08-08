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
        public bool IsSignIn = false;

        public ICommand SignInCommand { get; set; }
        public ICommand OpenCategoryCommand { get; set; }
        public ICommand StartTimerCommand { get; set; }
        public ICommand StopTimerCommand { get; set; }

        private SignInWindow _signInWindow;
        private CategoryWindow _categoryWindow;

        public MainViewModel(IAbstractFactory<SignInWindow> signInWindow, IAbstractFactory<CategoryWindow> categoryWindow)
        {                       
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
                
                _signInWindow = signInWindow.Create();
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
                    IsSignIn = signInVM.IsSignIn;
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
                
                _categoryWindow = categoryWindow.Create();

                if (IsSignIn == false)
                {
                    p.Close();
                    _signInWindow = signInWindow.Create();
                    
                    var signInVM = _signInWindow.DataContext as SignInViewModel;                    
                    _signInWindow.ShowDialog();

                    if (!signInVM.IsOpen && signInVM.IsSignIn)
                    {
                        IsSignIn = signInVM.IsSignIn;                        
                        _signInWindow.Close();
                    } 
                    else if (!signInVM.IsOpen)
                    {
                        _categoryWindow.Close();
                        _signInWindow.Close();
                    }
                }
                
                if (IsSignIn == true)
                {
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
