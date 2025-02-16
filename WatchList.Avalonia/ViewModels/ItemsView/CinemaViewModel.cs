using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using WatchList.Avalonia.Models;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;

namespace WatchList.Avalonia.ViewModels.ItemsView
{
    public abstract partial class CinemaViewModel : ViewModelBase
    {
        protected readonly IMessageBox _messageBox;
        protected readonly WatchItemService _watchItemService;
        protected readonly WatchItemCreator _watchItemCreator;
        protected readonly ILogger<WatchItemRepository> _logger;

        protected WatchItem _defaultWatchItem;

        private bool _isWatch;

        private TypeCinema _type;
        private StatusCinema _status;

        [ObservableProperty] private DateTimeOffset _maxDateWatched;
        [ObservableProperty] private DateTimeOffset _minDateWatched;
        [ObservableProperty] private string _labelSequelType;

        [ObservableProperty] private Guid _id;
        [ObservableProperty] private string _title;
        [ObservableProperty] private int _sequel;
        [ObservableProperty] private DateTimeOffset? _date;
        [ObservableProperty] private int? _grade;

        protected CinemaViewModel(IMessageBox messageBox,
                                  WatchItemService watchItemService,
                                  WatchItemCreator watchItemCreator,
                                  ILogger<WatchItemRepository> logger)
        {
            _messageBox = messageBox;
            _watchItemService = watchItemService;
            _watchItemCreator = watchItemCreator;
            _logger = logger;

            MaxDateWatched = DateTime.Now;
            MinDateWatched = new DateTime(1945, 1, 1);

            SaveCinemaCommand = ReactiveCommand.CreateFromTask<Window, bool?>(SaveCinema);
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
                    Date = value ? MaxDateWatched : null;
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

        protected abstract Task<bool?> SaveCinema(Window currentWindowAdd);

        [RelayCommand] protected abstract void SetDefaultValues();

        [RelayCommand] public void CloseWindow(Window window) => window.Close();

        public ReactiveCommand<Window, bool?> SaveCinemaCommand { get; }

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
            : _watchItemCreator.CreateNonPlanned(Title, Sequel, SelectedStatusCinema, SelectedTypeCinema, Date!.Value.DateTime, Grade, Id);
    }
}
