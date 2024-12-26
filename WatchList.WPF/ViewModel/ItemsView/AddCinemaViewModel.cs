using System.Windows;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;
using WatchList.WPF.Models;

namespace WatchList.WPF.ViewModel.ItemsView
{
    public class AddCinemaViewModel : CinemaViewModel
    {
        public AddCinemaViewModel(IMessageBox messageBox, WatchItemRepository watchItemRepository, WatchItemCreator watchItemCreator)
            : base(messageBox, watchItemRepository, watchItemCreator)
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
            _watchItemRepository.Add(GetCinema());
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
