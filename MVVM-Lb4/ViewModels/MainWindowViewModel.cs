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
}