using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
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
using MVVM_Lb4.Json.Commands.AddCommands;
using MVVM_Lb4.Json.Commands.DeleteCommands;
using MVVM_Lb4.Json.Commands.UpdateCommands;
using MVVM_Lb4.StoresControllers;
using MVVM_Lb4.ViewModels;
using MVVM_Lb4.Views.Windows.Main;
using YouTubeViewers.WPF.HostBuilders;
using DeleteGroupCommand = MVVM_Lb4.EF.Commands.DeleteCommands.DeleteGroupCommand;

namespace MVVM_Lb4;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;
    
    private const SavingType AppSavingType = SavingType.JsonFiles;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .AddDbContext()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<GroupsStoreController>();

                #region Saving

                services.AddSingleton<IGetCollectionQuery<Group>>(provider => 
                    AppSavingType == SavingType.Database ? 
                        new GetAllGroupsQuery(provider.GetRequiredService<ApplicationDbContextFactory>()) : 
                        new GetAllGroupsQueryJson());
                services.AddSingleton<IGetCollectionQuery<Student>>(provider => 
                    AppSavingType == SavingType.Database ? 
                        new GetAllStudentsInGroupQuery(provider.GetRequiredService<ApplicationDbContextFactory>()) : 
                        new GetAllStudentsInGroupQueryJson());

                services.AddSingleton<IAddCommand<Group>> (provider => 
                    AppSavingType == SavingType.Database ? 
                        new AddGroupDbCommand(provider.GetRequiredService<ApplicationDbContextFactory>()) : 
                        new AddGroupCommandJson());
                services.AddSingleton<IAddCommand<Student>>(provider => 
                    AppSavingType == SavingType.Database ? 
                        new AddStudentDbCommand(provider.GetRequiredService<ApplicationDbContextFactory>()) : 
                        new AddStudentCommandJson());
                services.AddSingleton<IDeleteCommand<Group>>(provider => 
                    AppSavingType == SavingType.Database ? 
                        new DeleteGroupCommand(provider.GetRequiredService<ApplicationDbContextFactory>()) : 
                        new DeleteGroupCommandJson());
                services.AddSingleton<IUpdateCommand<Group>>(provider => 
                    AppSavingType == SavingType.Database ? 
                        new UpdateGroupCommand(provider.GetRequiredService<ApplicationDbContextFactory>()) : 
                        new UpdateGroupCommandJson());

                #endregion

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
        using (ApplicationDbContext context = groupsDbContextFactory.Create())
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
    
    private enum SavingType
    {
        Database = 1,
        JsonFiles = 2
    }
}

