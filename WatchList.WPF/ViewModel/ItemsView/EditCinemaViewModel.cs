using System.Windows;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.WPF.Models;

namespace WatchList.WPF.ViewModel.ItemsView
{
    public class EditCinemaViewModel : CinemaViewModel
    {
        public EditCinemaViewModel(IMessageBox messageBox,
                                   WatchItemService watchItemService,
                                   WatchItemCreator watchItemCreator)
            : base(messageBox, watchItemService, watchItemCreator)
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
                await _watchItemService.UpdateAsync(_defaultWatchItem, item);
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
