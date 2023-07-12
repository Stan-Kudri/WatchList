using System.Collections.ObjectModel;
using WatchList.Core.Model.Load;

namespace WatchList.WinForms.BindingItem.ModelDataLoad
{
    public class ModelDownloadMoreGrade : ModelBase
    {
        private Grade _value = Grade.ExcludeGrade;

        public ModelDownloadMoreGrade()
            : this(Grade.ExcludeGrade)
        {
        }

        public ModelDownloadMoreGrade(Grade value) => _value = value;

        public ObservableCollection<Grade> Items { get; set; }
            = new ObservableCollection<Grade>(Grade.List.OrderBy(x => x.Value));

        public Grade Value
        {
            get => _value;
            set => SetField(ref _value, value);
        }
    }
}
