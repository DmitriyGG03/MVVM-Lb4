using MVVM_Lb4.ViewModels.Base;
using YouTubeViewers.WPF.Stores;

namespace MVVM_Lb4.ViewModels;

public class MainViewModel : ViewModel
{
    private readonly ModalNavigationStore _modalNavigationStore;

    public ViewModel CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
    public bool IsModalOpen => _modalNavigationStore.IsOpen;

    public GroupViewModel GroupViewModel { get; }

    public MainViewModel(ModalNavigationStore modalNavigationStore, GroupViewModel groupViewModel)
    {
        _modalNavigationStore = modalNavigationStore;
        GroupViewModel = groupViewModel;

        _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;
    }

    private void ModalNavigationStore_CurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentModalViewModel));
        OnPropertyChanged(nameof(IsModalOpen));
    }
}