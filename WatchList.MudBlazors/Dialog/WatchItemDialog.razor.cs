using Microsoft.AspNetCore.Components;
using MudBlazor;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Service;
using WatchList.MudBlazors.Extension;
using WatchList.MudBlazors.Model;

namespace WatchList.MudBlazors.Dialog
{
    public partial class WatchItemDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; } = null!;
        [Inject] private WatchItemService WatchItemService { get; set; } = null!;
        [Inject] private IDialogService DialogService { get; set; } = null!;

        private WatchItemModel _watchItemModel { get; set; } = new WatchItemModel();
        private string[] _errors = { };
        private bool _isAddItem = true;

        private WatchItem? _oldWatchItem;

        [Parameter] public Guid? Id { get; set; } = null;

        protected override void OnInitialized()
        {
            if (Id == null)
            {
                _isAddItem = true;
                return;
            }

            _isAddItem = false;
            _oldWatchItem = WatchItemService.GetItemById((Guid)Id);
            _watchItemModel = _oldWatchItem.GetItemModel();
        }

        private void Close() => MudDialog.Cancel();

        //Methods for add item type product
        private async Task Add()
        {
            if (_errors.Length != 0)
            {
                return;
            }

            if (!ValidateFields(out var message))
            {
                ShowMessageWarning(message);
                return;
            }

            var item = _watchItemModel.ToWatchItem();
            WatchItemService.Add(item);

            MudDialog.Close();
        }

        private void ClearData() => _watchItemModel.ClearData();

        //Methods for edit item type product
        private async Task Updata()
        {
            if (_errors.Length != 0)
            {
                return;
            }

            if (!ValidateFields(out var message))
            {
                ShowMessageWarning(message);
                return;
            }

            var item = _watchItemModel.ToWatchItem();
            if (!_oldWatchItem.Equals(item))
            {
                WatchItemService.Updata(_oldWatchItem, item);
            }

            MudDialog.Close();
        }

        private void RecoverPastData() => _watchItemModel = _oldWatchItem.GetItemModel();

        private IEnumerable<string> ValidFormatText(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                yield return "Field is required.";
            }
        }

        private async Task ShowMessageWarning(string message)
            => await DialogService.ShowMessageBox("Warning", message, yesText: "Ok");

        private bool ValidateFields(out string message)
        {
            message = string.Empty;

            if (_watchItemModel.Title == null || _watchItemModel.Title == string.Empty)
            {
                message = "Title is required.";
                return false;
            }

            if (_watchItemModel.Type == null)
            {
                message = "Type cinema not selected.";
                return false;
            }

            if (_watchItemModel.Status == null)
            {
                message = "Status not selected.";
                return false;
            }

            if (_watchItemModel.Grade <= 0)
            {
                message = $"Grade cinema above in zero.";
                return false;
            }

            if (_watchItemModel.Sequel == 0)
            {
                message = $"Enter number {_watchItemModel.Title}";
                return false;
            }

            return true;
        }
    }
}
