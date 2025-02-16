using System.Windows;
using Microsoft.Extensions.Logging;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.WPF.Models;

namespace WatchList.WPF.ViewModel.ItemsView
{
    public class AddCinemaViewModel : CinemaViewModel
    {
        public AddCinemaViewModel(IMessageBox messageBox,
                                  WatchItemService watchItemService,
                                  WatchItemCreator watchItemCreator,
                                  ILogger<WatchItemRepository> logger)
            : base(messageBox, watchItemService, watchItemCreator, logger)
        {
        }

        public override void InitializeDefaultValue(WatchItem? watchItem = null)
        {
            _defaultWatchItem = new WatchItemModel();
            SetDefaultValues();
            LabelSequelType = SelectedTypeCinema.TypeSequel;
        }

        public override string TitleWindow => "Add Item";

        protected override async Task SaveCinema(Window currentWindowAdd)
        {
            if (!ValidateFields(out var errorMessage))
            {
                await _messageBox.ShowWarning(errorMessage);
                return;
            }

            currentWindowAdd.DialogResult = true;

            var item = GetCinema();
            _logger.LogInformation($"Add Item : {item.Title}");
            await _watchItemService.AddAsync(item);

            currentWindowAdd.Close();
        }

        protected override void SetDefaultValues()
        {
            Title = _defaultWatchItem.Title;
            Sequel = _defaultWatchItem.Sequel;
            Grade = _defaultWatchItem.Grade;
            SelectedStatusCinema = _defaultWatchItem.Status;
            SelectedTypeCinema = _defaultWatchItem.Type;
        }
    }
}
