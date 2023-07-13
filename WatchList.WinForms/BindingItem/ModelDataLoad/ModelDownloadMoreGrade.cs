using System.Collections.ObjectModel;
using WatchList.Core.Model.Load;

namespace WatchList.WinForms.BindingItem.ModelDataLoad
{
    public class ModelDownloadMoreGrade : ModelBase
    {
        private Grade _value = Grade.AnyGrade;

        public ModelDownloadMoreGrade()
            : this(Grade.AnyGrade)
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
