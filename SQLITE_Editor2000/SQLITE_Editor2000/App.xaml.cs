using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQLITE_Editor2000.Data;
using SQLITE_Editor2000.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SQLITE_Editor2000
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddEnvironmentVariables();

            Configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddLogging();

            ViewModelInstaller(services, Configuration);
            var ServiceProvider = services.BuildServiceProvider();

            var test = Configuration.GetValue<string>("DBSourceFolder");

            var mainWindow = ServiceProvider.GetService<MainWindowViewModel>();


            mainWindow.ShowWindow();

        }

        private void ViewModelInstaller(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>
    (Configuration.GetSection(nameof(AppSettings)));

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<CreateDataBaseWindowViewModel>(); 
    
        }
    }
}
