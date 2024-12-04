using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using WatchList.Core.Model.Load;

namespace WatchList.WPF.Models.ModelDataLoad.LoadModel
{
    public class ModelDownloadMoreGrade : BindableBase
    {
        private Grade _value = Grade.AnyGrade;

        public ModelDownloadMoreGrade()
            : this(Grade.AnyGrade)
        {
        }

        public ModelDownloadMoreGrade(Grade value)
            => _value = value;

        public ObservableCollection<Grade> Items { get; set; }
            = new ObservableCollection<Grade>(Grade.List.OrderBy(x => x.Value));

        public Grade Value
        {
            get => _value;
            set => SetValue(ref _value, value, nameof(Value));
        }
    }
}
