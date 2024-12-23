using System.Windows;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Mvvm;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;
using WatchList.WPF.Models;

namespace WatchList.WPF.ViewModel.ItemsView
{
    public abstract partial class CinemaViewModel : BindableBase
    {
        protected readonly IMessageBox _messageBox;
        protected readonly WatchItemRepository _watchItemRepository;
        protected readonly WatchItemCreator _watchItemCreator;

        protected WatchItem? _defaultWatchItem;

        private bool _isWatch;

        private DateTime _maxDateWatched;
        private DateTime _minDateWatched;
        private string _labelSequelType;

        private Guid _id;
        private string _title;
        private TypeCinema _type;
        private int _sequel;
        private StatusCinema _status;
        private DateTime? _date;
        private int? _grade;

        protected CinemaViewModel(IMessageBox messageBox, WatchItemRepository watchItemRepository, WatchItemCreator watchItemCreator)
        {
            _messageBox = messageBox;
            _watchItemRepository = watchItemRepository;
            _watchItemCreator = watchItemCreator;

            MaxDateWatched = DateTime.Now;
            MinDateWatched = new DateTime(1945, 1, 1);
        }

        public abstract void InitializeDefaultValue(WatchItem? watchItem = null);

        public abstract string TitleWindow { get; }

        public DateTime MaxDateWatched
        {
            get => _maxDateWatched;
            set => _maxDateWatched = value;
        }

        public DateTime MinDateWatched
        {
            get => _minDateWatched;
            set => _minDateWatched = value;
        }

        public string LabelSequelType
        {
            get => _labelSequelType;
            set => SetValue(ref _labelSequelType, value);
        }

        public bool IsWatch
        {
            get => _isWatch;
            set
            {
                if (SetGrade == null || SetDateTime == null)
                {
                    SetGrade = value ? 1 : null;
                    SetDateTime = value ? DateTime.Now : null;
                }

                SetValue(ref _isWatch, value);
            }
        }

        public IEnumerable<StatusCinema> ListStatus => StatusCinema.List;
        public IEnumerable<TypeCinema> ListType => TypeCinema.List;

        public TypeCinema SelectedTypeCinema
        {
            get => _type;
            set
            {
                LabelSequelType = value.TypeSequel;
                SetValue(ref _type, value);
            }
        }

        public StatusCinema SelectedStatusCinema
        {
            get => _status;
            set
            {
                IsWatch = value != StatusCinema.Planned ? true : false;
                SetValue(ref _status, value);
            }
        }
        public string SetTitle
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        public int? SetGrade
        {
            get => _grade;
            set => SetValue(ref _grade, value);
        }

        public DateTime? SetDateTime
        {
            get => _date;
            set => SetValue(ref _date, value);
        }

        public int SetSequel
        {
            get => _sequel;
            set => SetValue(ref _sequel, value);
        }

        public Guid SetId
        {
            get => _id;
            set => SetValue(ref _id, value);
        }

        [RelayCommand]
        protected abstract Task SaveCinema(Window currentWindowAdd);

        [RelayCommand]
        protected void CloseWindow(Window window) => window?.Close();

        [RelayCommand]
        protected abstract void SetDefaultValues();

        protected bool ValidateFields(out string errorMessage)
        {
            if (SetTitle.Length <= 0)
            {
                errorMessage = $"Enter {SelectedTypeCinema.Name} title";
                return false;
            }
            else if (SetSequel == 0)
            {
                errorMessage = $"Enter number {SelectedTypeCinema.Name}";
                return false;
            }
            else if (SetGrade == 0)
            {
                errorMessage = "Grade cinema above in zero";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public WatchItem GetCinema()
            => SelectedStatusCinema == StatusCinema.Planned
            ? _watchItemCreator.CreatePlanned(SetTitle, SetSequel, SelectedStatusCinema, SelectedTypeCinema, SetId)
            : _watchItemCreator.CreateNonPlanned(SetTitle, SetSequel, SelectedStatusCinema, SelectedTypeCinema, SetDateTime, SetGrade, SetId);
    }
}
