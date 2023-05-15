using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF;
using MVVM_Lb4.EF.Commands.AddCommands;
using MVVM_Lb4.EF.Commands.DeleteCommands;
using MVVM_Lb4.EF.Commands.UpdateCommands;
using MVVM_Lb4.EF.Queries;
using MVVM_Lb4.Stores;
using MVVM_Lb4.ViewModels;
using MVVM_Lb4.Views.Windows.Main;
using YouTubeViewers.WPF.HostBuilders;
using DeleteGroupCommand = MVVM_Lb4.EF.Commands.DeleteCommands.DeleteGroupCommand;

namespace MVVM_Lb4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddDbContext()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<GroupsStoreController>();
                    
                    services.AddSingleton<IGetCollectionQuery<Group>, GetAllGroupsQuery>();
                    services.AddSingleton<IGetCollectionQuery<Student>, GetAllStudentsInGroupQuery>();
                    
                    services.AddTransient<IAddCommand<Group>, AddGroupDbCommand>();
                    services.AddTransient<IAddCommand<Student>, AddStudentDbCommand>();
                    services.AddTransient<IDeleteCommand<Group>, DeleteGroupCommand>();
                    services.AddTransient<IUpdateCommand<Group>, UpdateGroupCommand>();

                    services.AddSingleton<GroupsViewModel>();
                    services.AddSingleton<MainWindowViewModel>();

                    services.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainWindowViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            ApplicationDbContextFactory groupsDbContextFactory = 
                _host.Services.GetRequiredService<ApplicationDbContextFactory>();
            using(ApplicationDbContext context = groupsDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}