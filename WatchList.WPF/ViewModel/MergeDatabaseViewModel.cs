using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.Load.Components;
using WatchList.Core.Model.Load.ItemActions;
using WatchList.Core.Service.Component;
using WatchList.WPF.Models.ModelDataLoad;
using WatchList.WPF.Models.ModelDataLoad.LoadModel;

namespace WatchList.WPF.ViewModel
{
    [ObservableObject]
    public partial class MergeDatabaseViewModel
    {
        private readonly FileLoaderDB _fiileLoader;
        private readonly IMessageBox _messageBox;

        [ObservableProperty] private TypeCinemaModel selectTypeLoadCinema;
        [ObservableProperty] private Grade selectGradeLoadCinema;

        [ObservableProperty] private bool isExistGrade;

        [ObservableProperty] private bool isConsiderDuplicate;
        [ObservableProperty] private bool isUpdateDuplicateItem;
        [ObservableProperty] private bool isCaseSensitive;

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
                _fiileLoader.DownloadDataToDB(loadRuleConfig);
                window.DialogResult = true;
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
