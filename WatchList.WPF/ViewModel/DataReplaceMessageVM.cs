using System.Windows;
using CommunityToolkit.Mvvm.Input;
using WatchList.Core.Model.QuestionResult;

namespace WatchList.WPF.ViewModel
{
    public class DataReplaceMessageVM
    {
        public const string Question = "The append item is a duplicate.Replace element?";

        private readonly string _titleLabel;

        public DataReplaceMessageVM(string titleItem)
            => _titleLabel = titleItem;

        public string QuestionLabel => Question;
        public string TitleLabel => _titleLabel;

        public DialogReplaceItemQuestion ResultQuestion { get; private set; } = DialogReplaceItemQuestion.Unknown;

        public RelayCommand<Window> MoveYesCommand => new(MoveYesClick);
        public RelayCommand<Window> MoveAllYesCommand => new(MoveAllYesClick);
        public RelayCommand<Window> MoveNoCommand => new(MoveNoClick);
        public RelayCommand<Window> MoveAllNoCommand => new(MoveAllNoClick);

        private void MoveYesClick(Window window)
        {
            ResultQuestion = DialogReplaceItemQuestion.Yes;
            window.DialogResult = true;
            window?.Close();
        }

        private void MoveAllYesClick(Window window)
        {
            ResultQuestion = DialogReplaceItemQuestion.AllYes;
            window.DialogResult = true;
            window?.Close();
        }

        private void MoveNoClick(Window window)
        {
            ResultQuestion = DialogReplaceItemQuestion.No;
            window.DialogResult = true;
            window?.Close();
        }

        private void MoveAllNoClick(Window window)
        {
            ResultQuestion = DialogReplaceItemQuestion.AllNo;
            window.DialogResult = true;
            window?.Close();
        }
    }
}
