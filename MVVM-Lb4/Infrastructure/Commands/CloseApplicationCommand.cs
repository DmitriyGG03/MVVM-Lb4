using System;
using System.Windows;
using MVVM_Lb4.Infrastructure.Commands.Base;

namespace MVVM_Lb4.Infrastructure.Commands;

internal class CloseApplicationCommand : Command
{
    public override bool CanExecute(object parameter) => true;

    public override void Execute(object parameter) => Application.Current.Shutdown();
}