using System.Windows;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.Load.Components;
using WatchList.Core.Model.Load.ItemActions;
using WatchList.Core.Service.Component;
using WatchList.WPF.Models.ModelDataLoad.LoadModel;

namespace WatchList.WPF.Views
{
    /// <summary>
    /// Interaction logic for MergeDatabasePage.xaml
    /// </summary>
    public partial class MergeDatabaseWindow : Window
    {
        private readonly IMessageBox _messageBox;
        private readonly ModelTypeCinemaUpload _modelTypeCinemaUpload = new ModelTypeCinemaUpload();
        private readonly ModelDownloadMoreGrade _modelDownloadMoreGrade = new ModelDownloadMoreGrade();

        public MergeDatabaseWindow(IMessageBox messageBox)
        {
            InitializeComponent();
            _messageBox = messageBox;
        }

        private TypeLoadingCinema SelectTypeCinema
            => ComboBoxType.SelectedValue != null
            ? (TypeLoadingCinema)ComboBoxType.SelectedValue
            : throw new ArgumentNullException("Wrong combo box format");

        private Grade SelectGrade
            => ComboBoxMoreGrade.SelectedValue != null
            ? (Grade)ComboBoxMoreGrade.SelectedValue
            : throw new ArgumentNullException("Wrong combo box format");

        public ILoadRulesConfig GetLoadRuleConfig()
        {
            var isDeleteGrade = CheckBoxExistGrade.IsChecked ?? false;
            var considerDuplicates = CheckBoxConsiderDuplicates.IsChecked ?? false;

            if (!considerDuplicates)
            {
                return new LoadRulesConfigModel(isDeleteGrade, new ActionDuplicateItems(), SelectTypeCinema.Value, SelectGrade);
            }

            var listDuplicateLoadRule = GetListDuplicateLoadingRules();
            return new LoadRulesConfigModel(isDeleteGrade, new ActionDuplicateItems(considerDuplicates, listDuplicateLoadRule), SelectTypeCinema.Value, SelectGrade);
        }

        private async void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (await _messageBox.ShowQuestion("Add data from a file using the following algorithm?"))
            {
                DialogResult = true;
            }
            else
            {
                return;
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
            => SetupDefaultValues();

        private void BtnClose_Click(object sender, RoutedEventArgs e)
            => Close();

        private void LoadingDBWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxType.ItemsSource = _modelTypeCinemaUpload.Items;
            ComboBoxMoreGrade.ItemsSource = _modelDownloadMoreGrade.Items;
            ComboBoxType.SelectedItem = _modelTypeCinemaUpload.SelectedValue;
            ComboBoxMoreGrade.SelectedItem = Grade.AnyGrade;
            CheckBoxExistGrade.IsChecked = false;
            CheckBoxConsiderDuplicates.IsChecked = false;
        }

        private void CheckBoxConsiderDuplicates_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxUpdateDuplicateItem.IsEnabled = CheckBoxCaseSensitive.IsEnabled = true;
        }

        private void CheckBoxConsiderDuplicates_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxUpdateDuplicateItem.IsEnabled = CheckBoxCaseSensitive.IsEnabled = false;
        }

        private void SetupDefaultValues()
        {
            ComboBoxType.SelectedItem = _modelTypeCinemaUpload.SelectedValue;
            ComboBoxMoreGrade.SelectedItem = Grade.AnyGrade;
            CheckBoxExistGrade.IsChecked =
                CheckBoxConsiderDuplicates.IsChecked =
                    CheckBoxCaseSensitive.IsChecked =
                        CheckBoxUpdateDuplicateItem.IsChecked =
                            false;
        }

        private List<DuplicateLoadingRules> GetListDuplicateLoadingRules()
        {
            if (CheckBoxConsiderDuplicates.IsChecked == null || CheckBoxConsiderDuplicates.IsChecked == false)
            {
                return new List<DuplicateLoadingRules>();
            }

            var listConsiderDuplicates = new List<DuplicateLoadingRules>();

            if (CheckBoxUpdateDuplicateItem.IsChecked == true)
            {
                listConsiderDuplicates.Add(DuplicateLoadingRules.UpdateDuplicate);
            }

            if (CheckBoxCaseSensitive.IsChecked == true)
            {
                listConsiderDuplicates.Add(DuplicateLoadingRules.CaseSensitive);
            }

            return listConsiderDuplicates;
        }
    }
}
