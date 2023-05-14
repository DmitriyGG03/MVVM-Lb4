using System;
using System.Threading.Tasks;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb4.Stores;
using MVVM_Lb4.ViewModels;

namespace YouTubeViewers.WPF.Commands;

    public class LoadGroupsCommand : AsyncCommandBase
    {
        private readonly GroupsStoreController _groupsStore;

        public LoadGroupsCommand(GroupsStoreController groupsStore)
        {
            _groupsStore = groupsStore;
        }

        public override async Task ExecuteAsync(object parameter) => await _groupsStore.LoadGroups();
    }
