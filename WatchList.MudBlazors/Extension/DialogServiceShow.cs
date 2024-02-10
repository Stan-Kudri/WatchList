using MudBlazor;
using WatchList.MudBlazors.Message;

namespace WatchList.MudBlazors.Extension
{
    public static class DialogServiceShow
    {
        public static bool DialogYesNoShow(this IDialogService dialogService, string title, string content)
        {
            var parameters = new DialogParameters<DialogYesNo> { { x => x.Content, content } };
            return DialogShow(parameters, dialogService, title, content);
        }

        public static bool DialogOkCloseShow(this IDialogService dialogService, string title, string content)
        {
            var parameters = new DialogParameters<DialogYesNo>
            {
                {x => x.Content, content },
                {x => x.SelectButtonDialog, new Dictionary<bool, string>
                    {
                        {true, "Ok"},
                        {false, "Close"},
                    }
                }
            };
            return DialogShow(parameters, dialogService, title, content);
        }

        private static bool DialogShow(DialogParameters<DialogYesNo> dialogParameters, IDialogService dialogService, string title, string content)
        {

            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = dialogService.Show<DialogYesNo>(title, dialogParameters, options);
            var result = dialog.Result.Result;
            return result == null || !result.Cancelled;
        }
    }
}
