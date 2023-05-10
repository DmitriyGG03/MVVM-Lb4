using System;
using System.Windows;
using MVVM_Lb4.Commands.Base;

namespace MVVM_Lb4.Commands;

internal class CloseApplicationCommand : CommandBase
{
    public override bool CanExecute(object parameter) => true;

    public override void Execute(object parameter) => Application.Current.Shutdown();
}