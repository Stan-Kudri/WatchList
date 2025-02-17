using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.WPF.Models;

namespace WatchList.WPF.ViewModel.ItemsView
{
    public abstract partial class CinemaViewModel : ObservableObject
    {
        protected readonly IMessageBox _messageBox;
        protected readonly WatchItemService _watchItemService;
        protected readonly WatchItemCreator _watchItemCreator;

        protected WatchItem _defaultWatchItem;

        private bool _isWatch;

        private TypeCinema _type;
        private StatusCinema _status;

        [ObservableProperty] private DateTime _maxDateWatched;
        [ObservableProperty] private DateTime _minDateWatched;
        [ObservableProperty] private string _labelSequelType;

        [ObservableProperty] private Guid _id;
        [ObservableProperty] private string _title;
        [ObservableProperty] private int _sequel;
        [ObservableProperty] private DateTime? _date;
        [ObservableProperty] private int? _grade;

        protected CinemaViewModel(IMessageBox messageBox,
                                  WatchItemService watchItemService,
                                  WatchItemCreator watchItemCreator)
        {
            _messageBox = messageBox;
            _watchItemService = watchItemService;
            _watchItemCreator = watchItemCreator;

            MaxDateWatched = DateTime.Now;
            MinDateWatched = new DateTime(1945, 1, 1);
        }

        public abstract void InitializeDefaultValue(WatchItem? watchItem = null);

        public abstract string TitleWindow { get; }

        public IEnumerable<StatusCinema> ListStatus => StatusCinema.List;
        public IEnumerable<TypeCinema> ListType => TypeCinema.List;

        public bool IsWatch
        {
            get => _isWatch;
            set
            {
                if (Grade == null || Date == null)
                {
                    Grade = value ? 1 : null;
                    Date = value ? DateTime.Now : null;
                }

                SetProperty(ref _isWatch, value);
            }
        }

        public TypeCinema SelectedTypeCinema
        {
            get => _type;
            set
            {
                LabelSequelType = value.TypeSequel;
                SetProperty(ref _type, value);
            }
        }

        public StatusCinema SelectedStatusCinema
        {
            get => _status;
            set
            {
                IsWatch = value != StatusCinema.Planned ? true : false;
                SetProperty(ref _status, value);
            }
        }

        [RelayCommand] protected abstract Task SaveCinema(Window currentWindowAdd);

        [RelayCommand] protected void CloseWindow(Window window) => window?.Close();

        [RelayCommand] protected abstract void SetDefaultValues();

        protected bool ValidateFields(out string errorMessage)
        {
            if (Title.Length <= 0)
            {
                errorMessage = $"Enter {SelectedTypeCinema.Name} title";
                return false;
            }
            else if (Sequel == 0)
            {
                errorMessage = $"Enter number {SelectedTypeCinema.Name}";
                return false;
            }
            else if (Grade == 0)
            {
                errorMessage = "Grade cinema above in zero";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public WatchItem GetCinema()
            => SelectedStatusCinema == StatusCinema.Planned
            ? _watchItemCreator.CreatePlanned(Title, Sequel, SelectedStatusCinema, SelectedTypeCinema, Id)
            : _watchItemCreator.CreateNonPlanned(Title, Sequel, SelectedStatusCinema, SelectedTypeCinema, Date, Grade, Id);
    }
}
