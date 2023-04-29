using System;

namespace MVVM_Lb4.Stores;

public class SelectedGroupStore
{
    private readonly YouTubeViewersStore _youTubeViewersStore;

    private YouTubeViewer _selectedYouTubeViewer;
    public YouTubeViewer SelectedYouTubeViewer
    {
        get
        {
            return _selectedYouTubeViewer;
        }
        set
        {
            _selectedYouTubeViewer = value;
            SelectedYouTubeViewerChanged?.Invoke();
        }
    }

    public event Action SelectedYouTubeViewerChanged;

    public SelectedYouTubeViewerStore(YouTubeViewersStore youTubeViewersStore)
    {
        _youTubeViewersStore = youTubeViewersStore;

        _youTubeViewersStore.YouTubeViewerAdded += YouTubeViewersStore_YouTubeViewerAdded;
        _youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;
    }

    private void YouTubeViewersStore_YouTubeViewerAdded(YouTubeViewer youTubeViewer)
    {
        SelectedYouTubeViewer = youTubeViewer;
    }

    private void YouTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
    {
        if(youTubeViewer.Id == SelectedYouTubeViewer?.Id)
        {
            SelectedYouTubeViewer = youTubeViewer;
        }
    }
}