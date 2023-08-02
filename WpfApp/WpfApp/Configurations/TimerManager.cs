using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfApp.Configurations
{
    public class TimerManager : ICommand
    {
        private static TimerManager? _instance;
        public static TimerManager Instance => _instance ??= new TimerManager();

        private DispatcherTimer _timer;

        public event EventHandler? CanExecuteChanged;

        private TimerManager()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter.ToString() == "start")
            {
                _timer.Tick += (s, e) =>
                {
                    Application.Current.MainWindow.Close();
                    //SignInWindow signInWindow = new SignInWindow();
                    //signInWindow.ShowDialog();
                };

                Application.Current.MainWindow.MouseMove += (s, e) =>
                {
                    _timer.Stop();
                    _timer.Start();
                };

                _timer.Start();
            }
            else if (parameter.ToString() == "stop")
            {
                _timer.Stop();
            }
        }
    }
}
