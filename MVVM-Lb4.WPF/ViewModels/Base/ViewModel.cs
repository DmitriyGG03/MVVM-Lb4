using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Lb4.ViewModels.Base;

public abstract class ViewModel : INotifyPropertyChanged, IDisposable
{
    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private bool _disposed;

    public virtual void Dispose(bool Disposing)
    {
        if (!Disposing || _disposed) return;
        _disposed = true;
    }
}