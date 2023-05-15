using System;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_Lb4.Commands.Base;

/// <summary>
/// Blank for asynchronous commands
/// Review needed
/// </summary>
public abstract class AsyncCommandBase : CommandBase
{
    private bool _isExecuting;
    public bool IsExecuting
    {
        get
        {
            return _isExecuting;
        }
        set
        {
            _isExecuting = value;
            //OnCanExecutedChanged();
        }
    }

    public override bool CanExecute(object parameter)
    {
        return !IsExecuting && base.CanExecute(parameter);
    }

    public override async void Execute(object parameter)
    {
        IsExecuting = true;

        try
        {
            await ExecuteAsync(parameter);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Operation Error: {ex.Message}");
        }
        finally
        {
            IsExecuting = false;
        }
    }

    public abstract Task ExecuteAsync(object parameter);
}