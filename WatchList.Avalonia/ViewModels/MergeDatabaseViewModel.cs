using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WatchList.Avalonia.Models.ModelDataLoad;
using WatchList.Avalonia.Models.ModelDataLoad.LoadModel;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.Load.Components;
using WatchList.Core.Model.Load.ItemActions;
using WatchList.Core.Service.Component;

namespace WatchList.Avalonia.ViewModel
{
    public partial class MergeDatabaseViewModel : ObservableObject
    {
        private readonly FileLoaderDB _fiileLoader;
        private readonly IMessageBox _messageBox;

        [ObservableProperty] private TypeCinemaModel _selectTypeLoadCinema;
        [ObservableProperty] private Grade _selectGradeLoadCinema;

        [ObservableProperty] private bool _isExistGrade;

        [ObservableProperty] private bool _isConsiderDuplicate;
        [ObservableProperty] private bool _isUpdateDuplicateItem;
        [ObservableProperty] private bool _isCaseSensitive;

        public MergeDatabaseViewModel(IMessageBox messageBox, FileLoaderDB fiileLoader)
        {
            _messageBox = messageBox;
            _fiileLoader = fiileLoader;
            SetupDefaultValues();
        }

        public IEnumerable<TypeCinemaModel> ListTypeLoadingCinema => TypeCinemaModel.GetItemsType;
        public IEnumerable<Grade> GradeLoadingCinema => Grade.List;

        [RelayCommand]
        private async Task LoadDB(Window window)
        {
            if (await _messageBox.ShowQuestion("Add data from a file using the following algorithm?"))
            {
                var loadRuleConfig = GetLoadRuleConfig();
                await _fiileLoader.DownloadDataToDB(loadRuleConfig);
            }

            window?.Close();
        }

        [RelayCommand]
        private void SetupDefaultValues()
        {
            SelectTypeLoadCinema = TypeCinemaModel.AllType;
            SelectGradeLoadCinema = Grade.AnyGrade;
            IsExistGrade = IsConsiderDuplicate =
                IsCaseSensitive = IsUpdateDuplicateItem = false;
        }

        [RelayCommand]
        private void CloseWindow(Window window) => window?.Close();

        private ILoadRulesConfig GetLoadRuleConfig()
        {
            if (!IsConsiderDuplicate)
            {
                return new LoadRulesConfigModel(IsExistGrade, new ActionDuplicateItems(), SelectTypeLoadCinema.Value, SelectGradeLoadCinema);
            }

            var listDuplicateLoadRule = GetDuplicateLoadingRules();
            return new LoadRulesConfigModel(IsExistGrade, new ActionDuplicateItems(IsConsiderDuplicate, listDuplicateLoadRule), SelectTypeLoadCinema.Value, SelectGradeLoadCinema);
        }

        private List<DuplicateLoadingRules> GetDuplicateLoadingRules()
        {
            if (!IsConsiderDuplicate)
            {
                return new List<DuplicateLoadingRules>();
            }

            var listConsiderDuplicates = new List<DuplicateLoadingRules>();

            if (IsUpdateDuplicateItem)
            {
                listConsiderDuplicates.Add(DuplicateLoadingRules.UpdateDuplicate);
            }

            if (IsCaseSensitive)
            {
                listConsiderDuplicates.Add(DuplicateLoadingRules.CaseSensitive);
            }

            return listConsiderDuplicates;
        }
    }
}
