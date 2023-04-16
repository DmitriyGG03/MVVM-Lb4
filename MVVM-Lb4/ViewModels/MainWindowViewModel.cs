using System.Windows;
using System.Windows.Input;
using MVVM_Lb4.Infrastructure.Commands;
using MVVM_Lb4.ViewModels.Base;

namespace MVVM_Lb4.ViewModels;

internal class MainWindowViewModel : ViewModel
{
    #region Title
    
    private string _title = "University Group Manager";

    /// <summary>Window title</summary>
    public string Title { get => _title;
        set => Set(ref _title, value);
    }
    
    #endregion Title
    
    #region Commands
    
    #region CloseApp

    public ICommand CloseApplicationCommand { get; }

    private void OnCloseApplicationCommandExecuted(object p)
    {
        Application.Current.Shutdown();
    }

    private bool CanCloseApplicationCommandExecute(object p) => true;

    #endregion CloseApp
    
    #endregion Commands

    public MainWindowViewModel()
    {
        #region Commands
        
        CloseApplicationCommand =
            new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        
        #endregion Commands
    }
}