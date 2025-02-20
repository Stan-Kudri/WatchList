using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Models;
using WatchList.Core.Model.QuestionResult;

namespace WatchList.Avalonia.Extension
{
    public static class MessageBoxReplaceItemExtension
    {
        public static async Task<DialogReplaceItemQuestion> GetDialogReplaceItem(this string titleItem)
        {
            var menager = MessageBoxManager.GetMessageBoxCustom(
                                                                 new MessageBoxCustomParams
                                                                 {
                                                                     ButtonDefinitions = new List<ButtonDefinition>
                                                                     {
                                                                         new ButtonDefinition { Name = DialogReplaceItemQuestion.Yes.Name, },
                                                                         new ButtonDefinition { Name = DialogReplaceItemQuestion.AllYes.Name, },
                                                                         new ButtonDefinition { Name = DialogReplaceItemQuestion.No.Name, },
                                                                         new ButtonDefinition { Name = DialogReplaceItemQuestion.AllNo.Name, }
                                                                     },
                                                                     ContentTitle = titleItem,
                                                                     ContentMessage = "The append item is a duplicate.Replace element?",
                                                                     Icon = MsBox.Avalonia.Enums.Icon.Question,
                                                                     WindowStartupLocation = WindowStartupLocation.CenterOwner,
                                                                     CanResize = false,
                                                                     MaxWidth = 400,
                                                                     MaxHeight = 500,
                                                                     SizeToContent = SizeToContent.WidthAndHeight,
                                                                     ShowInCenter = true,
                                                                     Topmost = false,
                                                                 });
            var messageShow = await menager.ShowWindowAsync();
            return await messageShow.ConvertToDialogReplaceItem();
        }

        private static Task<DialogReplaceItemQuestion> ConvertToDialogReplaceItem(this string? buttonDefinitionsName)
        {
            if (buttonDefinitionsName == DialogReplaceItemQuestion.Yes.Name)
            {
                return Task.FromResult(DialogReplaceItemQuestion.Yes);
            }
            else if (buttonDefinitionsName == DialogReplaceItemQuestion.AllYes.Name)
            {
                return Task.FromResult(DialogReplaceItemQuestion.AllYes);
            }
            else if (buttonDefinitionsName == DialogReplaceItemQuestion.No.Name)
            {
                return Task.FromResult(DialogReplaceItemQuestion.No);
            }
            else if (buttonDefinitionsName == DialogReplaceItemQuestion.AllNo.Name)
            {
                return Task.FromResult(DialogReplaceItemQuestion.AllNo);
            }

            return Task.FromResult(DialogReplaceItemQuestion.Unknown);
        }
    }
}
