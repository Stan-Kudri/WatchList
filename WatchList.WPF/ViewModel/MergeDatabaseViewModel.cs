using System.Windows;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Mvvm;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.Load.Components;
using WatchList.Core.Model.Load.ItemActions;
using WatchList.Core.Service.Component;
using WatchList.WPF.Models.ModelDataLoad;
using WatchList.WPF.Models.ModelDataLoad.LoadModel;

namespace WatchList.WPF.ViewModel
{
    public partial class MergeDatabaseViewModel : BindableBase
    {
        private readonly FileLoaderDB _fiileLoader;
        private readonly IMessageBox _messageBox;

        private TypeCinemaModel _selectTypeLoadCinema;
        private Grade _selectGradeLoadCinema;

        private bool _isExistGrade;

        private bool _isConsiderDuplicate;
        private bool _isUpdateDuplicateItem;
        private bool _isCaseSensitive;

        public MergeDatabaseViewModel(IMessageBox messageBox, FileLoaderDB fiileLoader)
        {
            _messageBox = messageBox;
            _fiileLoader = fiileLoader;
            SetupDefaultValues();
        }

        public TypeCinemaModel SelectTypeLoadCinema
        {
            get => _selectTypeLoadCinema;
            set => SetValue(ref _selectTypeLoadCinema, value);
        }

        public Grade SelectGradeLoadCinema
        {
            get => _selectGradeLoadCinema;
            set => SetValue(ref _selectGradeLoadCinema, value);
        }

        public bool IsExistGrade
        {
            get => _isExistGrade;
            set => SetValue(ref _isExistGrade, value);
        }

        public bool IsConsiderDuplicate
        {
            get => _isConsiderDuplicate;
            set => SetValue(ref _isConsiderDuplicate, value);
        }

        public bool IsUpdateDuplicateItem
        {
            get => _isUpdateDuplicateItem;
            set => SetValue(ref _isUpdateDuplicateItem, value);
        }

        public bool IsCaseSensitive
        {
            get => _isCaseSensitive;
            set => SetValue(ref _isCaseSensitive, value);
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
