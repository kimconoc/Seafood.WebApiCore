using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Configurations
{
    public static class ServiceExtension
    {
        public static void AddFormFactory<F>(this IServiceCollection services) where F : class
        {
            services.AddTransient<F>();
            services.AddSingleton<Func<F>>(x => () => x.GetService<F>()!);
            services.AddSingleton<IAbstractFactory<F>, AbstractFactory<F>>();
        }
    }
}
