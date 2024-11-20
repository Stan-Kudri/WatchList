using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.Load.Components;
using WatchList.Core.Model.Load.ItemActions;
using WatchList.Core.Service.Component;
using WatchList.WPF.Commands;
using WatchList.WPF.Models.ModelDataLoad;
using WatchList.WPF.Models.ModelDataLoad.LoadModel;

namespace WatchList.WPF.ViewModel
{
    public class MergeDatabaseViewModel : INotifyPropertyChanged
    {
        private readonly FiileLoaderDB _fiileLoader;
        private readonly IMessageBox _messageBox;

        private readonly ModelTypeCinemaUpload _modelTypeCinemaUpload = new ModelTypeCinemaUpload();
        private readonly ModelDownloadMoreGrade _modelDownloadMoreGrade = new ModelDownloadMoreGrade();

        private bool _isExistGrade;

        private bool _isConsiderDuplicate;
        private bool _isUpdateDuplicateItem;
        private bool _isCaseSensitive;

        public MergeDatabaseViewModel(IMessageBox messageBox, FiileLoaderDB fiileLoader)
        {
            _messageBox = messageBox;
            _fiileLoader = fiileLoader;
            SelectGradeLoadCinema = Grade.AnyGrade;
            SelectTypeLoadCinema = new TypeLoadingCinema();
            MergeDateFromDB = new RelayCommand<Window>(MoveLoadDB);
            CloseWindowCommand = new RelayCommand<Window>(CloseWindow);
            SetDefoultValueWindow = new RelayCommandApp(_ => SetupDefaultValues());
        }

        public TypeLoadingCinema SelectTypeLoadCinema
        {
            get => _modelTypeCinemaUpload.SelectedValue;
            set
            {
                _modelTypeCinemaUpload.SelectedValue = value;
                OnPropertyChanged(nameof(SelectTypeLoadCinema));
            }
        }
        public Grade SelectGradeLoadCinema
        {
            get => _modelDownloadMoreGrade.Value;
            set
            {
                _modelDownloadMoreGrade.Value = value;
                OnPropertyChanged(nameof(SelectGradeLoadCinema));
            }
        }

        public bool IsExistGrade
        {
            get => _isExistGrade;
            set
            {
                _isExistGrade = value;
                OnPropertyChanged(nameof(IsExistGrade));
            }
        }

        public bool IsConsiderDuplicate
        {
            get => _isConsiderDuplicate;
            set
            {
                _isConsiderDuplicate = value;
                OnPropertyChanged(nameof(IsConsiderDuplicate));
            }
        }

        public bool IsUpdateDuplicateItem
        {
            get => _isUpdateDuplicateItem;
            set
            {
                _isUpdateDuplicateItem = value;
                OnPropertyChanged(nameof(IsUpdateDuplicateItem));
            }
        }

        public bool IsCaseSensitive
        {
            get => _isCaseSensitive;
            set
            {
                _isCaseSensitive = value;
                OnPropertyChanged(nameof(IsCaseSensitive));
            }
        }

        public IEnumerable<TypeLoadingCinema> TypeLoadingCinemas => _modelTypeCinemaUpload.Items;
        public IEnumerable<Grade> GradeLoadingCinemas => _modelDownloadMoreGrade.Items;

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
            SelectTypeLoadCinema = new TypeLoadingCinema(TypeCinema.Movie);
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
