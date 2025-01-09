using System.Windows;
using Microsoft.Extensions.Logging;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;
using WatchList.WPF.Extension;
using WatchList.WPF.Models;

namespace WatchList.WPF.ViewModel.ItemsView
{
    public class EditCinemaViewModel : CinemaViewModel
    {
        public EditCinemaViewModel(IMessageBox messageBox, WatchItemRepository watchItemRepository, WatchItemCreator watchItemCreator, ILogger<WatchItemRepository> logger)
            : base(messageBox, watchItemRepository, watchItemCreator, logger)
        {
        }

        public override void InitializeDefaultValue(WatchItem? watchItem)
        {
            _defaultWatchItem = watchItem ?? throw new ArgumentException("Error selecting item.");
            SetDefaultValues();
            LabelSequelType = SelectedTypeCinema.TypeSequel;
        }

        public override string TitleWindow => "Edit Window";

        protected override async Task SaveCinema(Window currentWindowAdd)
        {
            if (!ValidateFields(out var errorMessage))
            {
                await _messageBox.ShowWarning(errorMessage);
                return;
            }

            var item = GetCinema();

            if (_defaultWatchItem.Equals(item))
            {
                await _messageBox.ShowInfo("No changed item cinema.");
            }
            else
            {
                currentWindowAdd.DialogResult = true;
                _logger.AddInformationEditItem(_defaultWatchItem, item);
                _watchItemRepository.Update(item);
            }

            currentWindowAdd.Close();
        }

        protected override void SetDefaultValues()
        {
            Id = _defaultWatchItem.Id;
            Title = _defaultWatchItem.Title;
            Sequel = _defaultWatchItem.Sequel;
            SelectedStatusCinema = _defaultWatchItem.Status;
            SelectedTypeCinema = _defaultWatchItem.Type;
            Grade = _defaultWatchItem.Grade;
            Date = _defaultWatchItem.Date;
        }
    }
}
