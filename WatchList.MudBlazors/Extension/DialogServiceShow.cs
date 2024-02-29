using MudBlazor;
using MudBlazor.Extensions;
using WatchList.Core.Model.QuestionResult;
using WatchList.MudBlazors.Message;

namespace WatchList.MudBlazors.Extension
{
    public static class DialogServiceShow
    {
        public static async Task<DialogReplaceItemQuestion> DialogReplaceLoadData(this IDialogService dialogService, string title, string titleItem)
        {
            var parameters = new DialogParameters<DialogLoadData> { { e => e.TitleItem, titleItem } };
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = await dialogService.ShowAsync<DialogLoadData>(title, parameters, options);
            var result = await dialog.Result;

            if (result == null || !result.Cancelled)
            {
                return result.Data.As<DialogReplaceItemQuestion>();
            }

            return DialogReplaceItemQuestion.AllNo;
        }

        public static async Task<bool> DialogYesNoShow(this IDialogService dialogService, string title, string content)
        {
            var parameters = new DialogParameters<DialogYesNo> { { x => x.Content, content } };
            return await DialogShowAsync(parameters, dialogService, title, content);
        }

        public static async Task<bool> DialogOkCloseShowAsync(this IDialogService dialogService, string title, string content)
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
            return await DialogShowAsync(parameters, dialogService, title, content);
        }

        private static async Task<bool> DialogShowAsync(DialogParameters<DialogYesNo> dialogParameters, IDialogService dialogService, string title, string content)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = await dialogService.ShowAsync<DialogYesNo>(title, dialogParameters, options);
            var result = await dialog.Result;
            return result == null || !result.Cancelled;
        }
    }
}
