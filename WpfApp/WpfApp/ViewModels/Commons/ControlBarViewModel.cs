using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp.ViewModels.Commons
{
    public class ControlBarViewModel : BaseViewModel
    {
        public ICommand MouseMoveWindowCommand { get; set; }

        public ControlBarViewModel()
        {

            MouseMoveWindowCommand = new RelayCommand<UserControl>(p =>
            {
                return p == null ? false : true;
            }, p =>
            {
                FrameworkElement element = GetParentWindow(p);
                var window = element as Window;
                if (window != null)
                {
                    window.DragMove();
                }
            });                        
        }

        public FrameworkElement GetParentWindow(UserControl parent)
        {
            FrameworkElement parentWindow = parent;
            while (parentWindow.Parent != null)
            {
                parentWindow = parentWindow.Parent as FrameworkElement;
            }

            return parentWindow;
        }
    }
}
