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
    public class AddCinemaViewModel : BindableBase
    {
        //private readonly CinemaModel _defaultCinemaModel;
        private readonly CinemaModel _cinemaModel;
        private readonly IMessageBox _messageBox;
        private readonly WatchItemRepository _watchItemRepository;

        private bool _isWatch;

        private DateTime _maxDateWatched;
        private DateTime _minDateWatched;
        private string _labelSequelType;

        public AddCinemaViewModel(IMessageBox messageBox, WatchItemRepository watchItemRepository)
            : this(messageBox, watchItemRepository, null)
        {
        }

        public AddCinemaViewModel(IMessageBox messageBox, WatchItemRepository watchItemRepository, WatchItem? watchItem = null)
        {
            _messageBox = messageBox;
            _watchItemRepository = watchItemRepository;
            _cinemaModel = CinemaModel.GetCinemaFromWatchItem(watchItem);
            MaxDateWatched = DateTime.Now;
            MinDateWatched = new DateTime(1945, 1, 1);
            LabelSequelType = SelectedTypeCinema.TypeSequel;
            SetDefoultValueCommand = new RelayCommand(SetDefaultValues);
            CloseWindowCommand = new RelayCommand<Window>(CloseWindow);
        }

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
                SetGrade = value ? 1 : null;
                SetDateTime = value ? DateTime.Now : null;
                SetValue(ref _isWatch, value);
            }
        }

        public IEnumerable<StatusCinema> ListStatus => StatusCinema.List;
        public IEnumerable<TypeCinema> ListType => TypeCinema.List;

        public RelayCommand SetDefoultValueCommand { get; private set; }
        public RelayCommand<Window> CloseWindowCommand { get; private set; }

        public TypeCinema SelectedTypeCinema
        {
            get => _cinemaModel.Type;
            set
            {
                LabelSequelType = value.TypeSequel;
                _cinemaModel.Type = value;
            }
        }

        public StatusCinema SelectedStatusCinema
        {
            get => _cinemaModel.Status;
            set
            {
                IsWatch = value != StatusCinema.Planned ? true : false;
                _cinemaModel.Status = value;
            }
        }

        public string SetTitle
        {
            get => _cinemaModel.Title;
            set => _cinemaModel.Title = value;
        }

        public int? SetGrade
        {
            get => _cinemaModel.Grade;
            set => _cinemaModel.Grade = value;
        }

        public DateTime? SetDateTime
        {
            get => _cinemaModel.Date;
            set => _cinemaModel.Date = value;
        }

        public int SetSequel
        {
            get => _cinemaModel.Sequel;
            set => _cinemaModel.Sequel = value;
        }

        /*
        public CinemaModel GetCinema()
        {
            decimal? grade = numericGradeCinema.Enabled == true ? numericGradeCinema.Value : null;
            DateTime? dateViewed = dateTimePickerCinema.Enabled == true ? dateTimePickerCinema.Value : null;

            return CinemaModel.CreateNonPlanned(txtAddCinema.Text, numericSequel.Value, dateViewed, grade, _status, SelectedTypeCinema);
        }                         */

        private async void MoveAddCinema(Window currentWindowAdd)
        {
            if (!ValidateFields(out var errorMessage))
            {
                await _messageBox.ShowWarning(errorMessage);
            }
            else
            {
                _watchItemRepository.Add(_cinemaModel.ToWatchItem());
                currentWindowAdd.Close();
            }
        }

        private void CloseWindow(Window window) => window?.Close();

        private void SetDefaultValues()
        {
            SetTitle = string.Empty;
            SetSequel = 1;
            SelectedTypeCinema = TypeCinema.Movie;
            SelectedStatusCinema = StatusCinema.Planned;
            _isWatch = false;
            RaisePropertyChanged(nameof(SelectedTypeCinema));
            RaisePropertyChanged(nameof(SelectedStatusCinema));
            RaisePropertyChanged(nameof(SetDateTime));

        }

        private bool ValidateFields(out string errorMessage)
        {
            if (_cinemaModel.Title.Length <= 0)
            {
                errorMessage = $"Enter {SelectedTypeCinema.Name} title";
                return false;
            }
            else if (_cinemaModel.Sequel == 0)
            {
                errorMessage = $"Enter number {SelectedTypeCinema.Name}";
                return false;
            }
            else if (_cinemaModel.Grade == 0)
            {
                errorMessage = "Grade cinema above in zero";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
