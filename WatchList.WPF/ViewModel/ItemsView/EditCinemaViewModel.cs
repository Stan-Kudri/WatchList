using System.Windows;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;
using WatchList.WPF.Models;

namespace WatchList.WPF.ViewModel.ItemsView
{
    public class EditCinemaViewModel : CinemaViewModel
    {
        public EditCinemaViewModel(IMessageBox messageBox, WatchItemRepository watchItemRepository, WatchItemCreator watchItemCreator)
            : base(messageBox, watchItemRepository, watchItemCreator)
        {
        }

        public override void InitializeDefaultValue(WatchItem? watchItem)
        {
            _defaultWatchItem = watchItem;
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
                _watchItemRepository.Update(item);
            }

            currentWindowAdd.Close();
        }

        protected override void SetDefaultValues()
        {
            SetId = _defaultWatchItem.Id;
            SetTitle = _defaultWatchItem.Title;
            SelectedStatusCinema = _defaultWatchItem.Status;
            SelectedTypeCinema = _defaultWatchItem.Type;
            SetGrade = _defaultWatchItem.Grade;
            SetDateTime = _defaultWatchItem.Date;
        }
    }
}
