using System;
using MVVM_Lb4.ViewModels.Base;

namespace MVVM_Lb4.Stores;

public class ModalNavigationStore
{
    private ViewModel _currentViewModel;

    public ViewModel CurrentViewModel
    {
        get { return _currentViewModel; }
        set
        {
            _currentViewModel = value;
            CurrentViewModelChanged?.Invoke();
        }
    }

    public bool IsOpen => CurrentViewModel != null;


    public event Action CurrentViewModelChanged;

    public void Close()
    {
        CurrentViewModel = null;
    }
}