using System.Windows;
using CommunityToolkit.Mvvm.Input;
using WatchList.Core.Model.QuestionResult;
using WatchList.WPF.Models.ModelDataLoad;

namespace WatchList.WPF.ViewModel
{
    public class DataReplaceMessageVM
    {
        public const string Question = "The append item is a duplicate.Replace element?";

        private readonly string _titleLabel;

        public DataReplaceMessageVM(string titleItem, DialogReplaceQuestionManager questionResult)
        {
            _titleLabel = titleItem;
            ResultQuestion = questionResult;
        }

        public string QuestionLabel => Question;
        public string TitleLabel => _titleLabel;

        public DialogReplaceQuestionManager ResultQuestion { get; private set; }

        public RelayCommand<Window> MoveYesCommand => new(MoveYesClick);
        public RelayCommand<Window> MoveAllYesCommand => new(MoveAllYesClick);
        public RelayCommand<Window> MoveNoCommand => new(MoveNoClick);
        public RelayCommand<Window> MoveAllNoCommand => new(MoveAllNoClick);

        private void MoveYesClick(Window window)
        {
            ResultQuestion.UpdateData(DialogReplaceItemQuestion.Yes);
            window.DialogResult = true;
            window?.Close();
        }

        private void MoveAllYesClick(Window window)
        {
            ResultQuestion.UpdateData(DialogReplaceItemQuestion.AllYes);
            window.DialogResult = true;
            window?.Close();
        }

        private void MoveNoClick(Window window)
        {
            ResultQuestion.UpdateData(DialogReplaceItemQuestion.No);
            window.DialogResult = true;
            window?.Close();
        }

        private void MoveAllNoClick(Window window)
        {
            ResultQuestion.UpdateData(DialogReplaceItemQuestion.AllNo);
            window.DialogResult = true;
            window?.Close();
        }
    }
}
