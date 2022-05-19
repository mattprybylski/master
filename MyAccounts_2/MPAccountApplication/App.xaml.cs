using AutoMapper;
 
using EF.Data.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP.EF.Business.AbstractBase;
using MPAccountApplication.ViewModel;
using MyAccountModels.AutoMapper;
using MyAccountsBusiness.BA;
using MyAccountsBusiness.DataEncryption;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MPAccountApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public static ILogger logger; 

        protected override void OnStartup(StartupEventArgs e)
        {
             logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
               .MinimumLevel.Override("System", LogEventLevel.Warning)
               .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
               .Enrich.FromLogContext()
               //.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate)
               .WriteTo.File("log.txt", retainedFileCountLimit: 7, rollingInterval: RollingInterval.Day)
               .CreateLogger();

            var builder = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddEnvironmentVariables();



            Configuration = builder.Build();
              var services = new ServiceCollection();
            //       ConfigureServices(serviceCollection, connection)
            var connection = Configuration.GetConnectionString("MpContext");
            services.AddDbContext<MpContext>(options => options.UseSqlServer(connection));
            services.AddScoped<UnitOfWork<MpContext>>();
     ;
            //   ServiceProvider = serviceCollection.BuildServiceProvider();
            //     var mainWindow = ServiceProvider.GetRequiredService<MainWindowViewModel>();
            string name = "Matthew";
            DataProtectionEncryption test = new DataProtectionEncryption();
            var encrypted = test.Encrypt(name);
            var decrypted = test.DecryptStringAES(encrypted);

            MainWindowViewModel mainWindow = new MainWindowViewModel(); 
            mainWindow.ShowWindowAsync(); 
        }


        private void ConfigureServices(IServiceCollection services, string connection)
        {


            services.AddLogging();
            services.AddDbContext<MpContext>(options => options.UseSqlServer(connection));
            services.AddScoped<UnitOfWork<MpContext>>();

            //services.AddTransient(typeof(CompanyBA));
            services.AddTransient(typeof(StateProvinceBA));
          //  services.AddTransient(typeof(BillExpenseTypeBA));
           // services.AddTransient(typeof(ExpenseBA));
            //services.AddTransient(typeof(MainWindowViewModel));
           services.AddTransient(typeof(MainWindowViewModel));
            services.AddTransient(typeof(StateProvinceViewModel));
        
            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
