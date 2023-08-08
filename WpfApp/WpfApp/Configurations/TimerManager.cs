using System;
using System.Collections.Generic;
using System.Linq;
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

        private readonly int _interval = 10;

        public static IAbstractFactory<SignInWindow> SignInWindow;

        private TimerManager()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(_interval)
            };
        }

        public void Start(Window currentWindow)
        {            
            _timer.Tick += (s, e) =>
            {
                if (!currentWindow.IsVisible)
                {
                    _timer.Stop();                    
                }
                else
                {
                    currentWindow.Hide();

                    SignInWindow signInWindow = SignInWindow.Create();
                    signInWindow.ShowDialog();

                    var signInVM = signInWindow.DataContext as SignInViewModel;

                    if (signInVM.IsOpen == false)
                    {
                        currentWindow.ShowDialog();
                    }
                }                
            };

            currentWindow.MouseMove += (s, e) =>
            {
                _timer.Stop();
                _timer.Start();
            };            

            _timer.Start();                       
        }

        public void Stop()
        {            
            _timer.Stop();
        }
    }
}
