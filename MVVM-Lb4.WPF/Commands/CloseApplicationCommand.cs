using System;
using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb4.Views.DialogWindows;

namespace MVVM_Lb4.Commands;

internal class CloseApplicationCommand : CommandBase
{
    public override bool CanExecute(object parameter) => true;

    public override void Execute(object parameter)
    {
        ConfirmOperationWindow confirmOperationWindow = new ConfirmOperationWindow("quit the application");

        if ((bool)confirmOperationWindow.ShowDialog()!)
        {
            Application.Current.Shutdown();
        }
    }
}