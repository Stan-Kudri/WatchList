using System.Threading.Tasks;
using Avalonia.Controls;
using WatchList.Avalonia.Models;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;

namespace WatchList.Avalonia.ViewModels.ItemsView
{
    public class AddCinemaViewModel : CinemaViewModel
    {
        public AddCinemaViewModel(IMessageBox messageBox,
                                  WatchItemService watchItemService,
                                  WatchItemCreator watchItemCreator)
            : base(messageBox, watchItemService, watchItemCreator)
        {
        }

        public override void InitializeDefaultValue(WatchItem? watchItem = null)
        {
            _defaultWatchItem = new WatchItemModel();
            SetDefaultValues();
            LabelSequelType = SelectedTypeCinema.TypeSequel;
        }

        public override string TitleWindow => "Add Item";

        protected override async Task<bool?> SaveCinema(Window currentWindowAdd)
        {
            if (!ValidateFields(out var errorMessage))
            {
                await _messageBox.ShowWarning(errorMessage);
                return null;
            }

            var item = GetCinema();
            await _watchItemService.AddAsync(item);

            return true;
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
