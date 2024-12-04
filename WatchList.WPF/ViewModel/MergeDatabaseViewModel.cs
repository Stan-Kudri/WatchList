using System.Windows;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Mvvm;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.Load.Components;
using WatchList.Core.Model.Load.ItemActions;
using WatchList.Core.Service.Component;
using WatchList.WPF.Commands;
using WatchList.WPF.Models.ModelDataLoad;
using WatchList.WPF.Models.ModelDataLoad.LoadModel;

namespace WatchList.WPF.ViewModel
{
    public class MergeDatabaseViewModel : BindableBase
    {
        private readonly FileLoaderDB _fiileLoader;
        private readonly IMessageBox _messageBox;

        private readonly ModelTypeCinemaUpload _modelTypeCinemaUpload = new ModelTypeCinemaUpload();
        private readonly ModelDownloadMoreGrade _modelDownloadMoreGrade = new ModelDownloadMoreGrade();

        private bool _isExistGrade;

        private bool _isConsiderDuplicate;
        private bool _isUpdateDuplicateItem;
        private bool _isCaseSensitive;

        public MergeDatabaseViewModel(IMessageBox messageBox, FileLoaderDB fiileLoader)
        {
            _messageBox = messageBox;
            _fiileLoader = fiileLoader;
            SelectGradeLoadCinema = _modelDownloadMoreGrade.Value;
            SelectTypeLoadCinema = _modelTypeCinemaUpload.SelectedValue;
            MergeDateFromDB = new RelayCommand<Window>(MoveLoadDB);
            CloseWindowCommand = new RelayCommand<Window>(CloseWindow);
            SetDefoultValueWindow = new RelayCommandApp(_ => SetupDefaultValues());
        }

        public TypeLoadingCinema SelectTypeLoadCinema
        {
            get => _modelTypeCinemaUpload.SelectedValue;
            set => _modelTypeCinemaUpload.SelectedValue = value;
        }

        public Grade SelectGradeLoadCinema
        {
            get => _modelDownloadMoreGrade.Value;
            set => _modelDownloadMoreGrade.Value = value;
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

        public IEnumerable<TypeLoadingCinema> TypeLoadingCinema => _modelTypeCinemaUpload.Items;
        public IEnumerable<Grade> GradeLoadingCinema => _modelDownloadMoreGrade.Items;

        public RelayCommand<Window> MergeDateFromDB { get; private set; }
        public RelayCommand<Window> CloseWindowCommand { get; private set; }
        public RelayCommandApp SetDefoultValueWindow { get; private set; }

        private async void MoveLoadDB(Window window)
        {
            if (await _messageBox.ShowQuestion("Add data from a file using the following algorithm?"))
            {
                var loadRuleConfig = GetLoadRuleConfig();
                _fiileLoader.DownloadDataToDB(loadRuleConfig);
            }

            window?.Close();
        }

        private void SetupDefaultValues()
        {
            SelectTypeLoadCinema = new TypeLoadingCinema(null);
            SelectGradeLoadCinema = Grade.AnyGrade;
            IsExistGrade = IsConsiderDuplicate =
                IsCaseSensitive = IsUpdateDuplicateItem = false;
        }

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

        private void CloseWindow(Window window) => window?.Close();
    }
}
