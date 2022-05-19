using AutoMapper;
using EF.Data.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP.EF.Business.AbstractBase;
using MPAccountAble.View;
using MyAccountModels.AutoMapper;
using MyAccounts_2.ViewModel;
using MyAccountsBusiness.BA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MPAccountAble
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>


    public partial class App : Application
    {

        public static IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();



            Configuration = builder.Build();

            var connection = Configuration.GetConnectionString("MpContext");

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, connection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<StateEditorViewModel>();
            mainWindow.ShowWindow();
        }

        private void ConfigureServices(IServiceCollection services, string connection)
        {


            services.AddLogging();
            services.AddDbContext<MpContext>(options => options.UseSqlServer(connection));
            services.AddScoped<UnitOfWork<MpContext>>();

            //services.AddTransient(typeof(CompanyBA));
            services.AddTransient(typeof(StateProvinceBA));
            //services.AddTransient(typeof(MainWindowViewModel));
            //services.AddTransient(typeof(CompanyWindowViewModel));
            services.AddTransient(typeof(StateEditorViewModel));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
