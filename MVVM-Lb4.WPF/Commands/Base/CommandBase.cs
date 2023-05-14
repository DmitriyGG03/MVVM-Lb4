using System;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Lb4.Commands.Base;

public abstract class CommandBase : ICommand
{
    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public virtual bool CanExecute(object parameter) => true;

    public abstract void Execute(object parameter);
    
    protected bool ValidateStringSyntaxEnteredData(string data, string paramName)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            MessageBox.Show("You must enter data in order to create a new object!", "Data error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        else if (data.Length < 3 || data.Length > 30)
        {
            MessageBox.Show($"{paramName} must have minimum 3 symbols and maximum 30", "Data error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        else return true;
    }
}