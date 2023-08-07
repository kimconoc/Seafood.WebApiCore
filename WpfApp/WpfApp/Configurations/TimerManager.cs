using System;
using System.Windows;
using System.Windows.Threading;
using WpfApp.ViewModels.Auth;
using WpfApp.Views.Auth;

namespace WpfApp.Configurations
{
    public class TimerManager
    {
        private static TimerManager? _instance;
        public static TimerManager Instance => _instance ??= new TimerManager();

        private readonly DispatcherTimer _timer;

        private readonly int _interval = 3;

        public static IAbstractFactory<SignInWindow> SignInWindow;

        private TimerManager()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(_interval)
            };
        }

        public void OnStart(Window currentWindow)
        {            
            _timer.Tick += (s, e) =>
            {
                currentWindow.Hide();

                SignInWindow signInWindow = SignInWindow.Create();
                signInWindow.ShowDialog();

                var signInVM = signInWindow.DataContext as SignInViewModel;

                if (!signInVM.IsOpen)
                {
                    signInWindow.Close();
                    currentWindow.ShowDialog();
                }
            };

            currentWindow.MouseMove += (s, e) =>
            {
                _timer.Stop();
                _timer.Start();
            };            

            _timer.Start();                       
        }

        public void OnStop()
        {            
            _timer.Stop();
        }
    }
}
