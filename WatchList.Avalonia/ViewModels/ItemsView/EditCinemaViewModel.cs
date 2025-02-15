using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Microsoft.Extensions.Logging;
using WatchList.Avalonia.Extension;
using WatchList.Avalonia.Models;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;

namespace WatchList.Avalonia.ViewModels.ItemsView
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

        protected override async Task<bool> SaveCinema(Window currentWindowAdd)
        {
            if (!ValidateFields(out var errorMessage))
            {
                await _messageBox.ShowWarning(errorMessage);
                return false;
            }

            var item = GetCinema();

            if (_defaultWatchItem.Equals(item))
            {
                await _messageBox.ShowInfo("No changed item cinema.");
            }
            else
            {
                //currentWindowAdd.DialogResult = true;
                _logger.AddInformationEditItem(_defaultWatchItem, item);
                _watchItemRepository.Update(item);
            }

            currentWindowAdd.Close();
            return true;
        }

        protected override void SetDefaultValues()
        {
            Id = _defaultWatchItem.Id;
            Title = _defaultWatchItem.Title;
            Sequel = _defaultWatchItem.Sequel;
            SelectedStatusCinema = _defaultWatchItem.Status;
            SelectedTypeCinema = _defaultWatchItem.Type;
            Grade = _defaultWatchItem.Grade;
            Date = new DateTimeOffset(_defaultWatchItem.Date!.Value);
        }
    }
}
