using DBLay;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestTask.Services;
using TestTask.View;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseMySql("server=localhost;user=root;password=root;database=mysql;",
            //    new MySqlServerVersion(new Version(5, 7, 22)));
            //});

            services.AddMySql<AppDbContext>("server=localhost;user=root;password=root;database=mysql;",
                new MySqlServerVersion(new Version(5, 7, 22)));

            services.AddSingleton<ItemHelper>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ItemHelperServices>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
