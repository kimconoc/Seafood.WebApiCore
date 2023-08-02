using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp.ViewModels.Commons
{
    public class ControlBarViewModel : BaseViewModel
    {
        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

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

            MinimizeWindowCommand = new RelayCommand<UserControl>((p) =>
            {
                return p == null ? false : true;
            }, (p) =>
            {
                FrameworkElement element = GetParentWindow(p);
                var window = element as Window;
                if (window != null)
                {
                    if (window.WindowState != WindowState.Minimized)
                        window.WindowState = WindowState.Minimized;
                    else
                        window.WindowState = WindowState.Maximized;
                }
            });

            MaximizeWindowCommand = new RelayCommand<UserControl>((p) =>
            {
                return p == null ? false : true;
            }, (p) =>
            {
                FrameworkElement element = GetParentWindow(p);
                var window = element as Window;
                if (window != null)
                {
                    if (window.WindowState != WindowState.Maximized)
                        window.WindowState = WindowState.Maximized;
                    else
                        window.WindowState = WindowState.Normal;
                }
            });

            CloseWindowCommand = new RelayCommand<UserControl>((p) =>
            {
                return p == null ? false : true;
            }, (p) =>
            {
                FrameworkElement element = GetParentWindow(p);
                var window = element as Window;
                window?.Close();
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
