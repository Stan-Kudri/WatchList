using System.Windows;
using CommunityToolkit.Mvvm.Input;
using WatchList.Core.Model.QuestionResult;
using WatchList.WPF.Extension;

namespace WatchList.WPF.ViewModel
{
    public partial class DataReplaceMessageVM
    {
        public const string Question = "The append item is a duplicate.Replace element?";

        private readonly string _titleLabel;

        public DataReplaceMessageVM(string titleItem) => _titleLabel = titleItem;

        public string QuestionLabel => Question;
        public string TitleLabel => _titleLabel;

        public DialogReplaceItemQuestion ResultQuestion { get; private set; } = DialogReplaceItemQuestion.Unknown;

        [RelayCommand]
        private void YesClick(Window window)
        {
            ResultQuestion = DialogReplaceItemQuestion.Yes;
            window.ClickButtonWindow();
        }

        [RelayCommand]
        private void AllYesClick(Window window)
        {
            ResultQuestion = DialogReplaceItemQuestion.AllYes;
            window.ClickButtonWindow();
        }

        [RelayCommand]
        private void NoClick(Window window)
        {
            ResultQuestion = DialogReplaceItemQuestion.No;
            window.ClickButtonWindow();
        }

        [RelayCommand]
        private void AllNoClick(Window window)
        {
            ResultQuestion = DialogReplaceItemQuestion.AllNo;
            window.ClickButtonWindow();
        }
    }
}
