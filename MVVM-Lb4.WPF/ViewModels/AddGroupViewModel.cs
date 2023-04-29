using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_Lb4.ViewModels.Base;
using YouTubeViewers.WPF.Stores;

namespace MVVM_Lb4.ViewModels
{
    public class AddYouTubeViewerViewModel : ViewModel
    {
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }

        public AddYouTubeViewerViewModel(YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand = new AddYouTubeViewerCommand(this, youTubeViewersStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
