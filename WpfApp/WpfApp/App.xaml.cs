using _2DataAccess.Interfaces;
using _2DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model.AppDbContexts;
using System.Windows;
using WpfApp.Configurations;
using WpfApp.Views.Auth;
using WpfApp.Views.Categories;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {                
                services.AddFormFactory<MainWindow>();
                services.AddFormFactory<SignInWindow>();
                services.AddFormFactory<CategoryWindow>();

                services.AddSingleton<SeafoodContext>();
                services.AddTransient<IUserRepository, UserRepository>();
                services.AddTransient<ICategoryRepository, CategoryRepository>();
            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            var startUpForm = AppHost.Services.GetRequiredService<MainWindow>();
            startUpForm.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
