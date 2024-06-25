using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Load
{
    public class BaseLoadRulesConfigModel : ILoadRulesConfig
    {
        public BaseLoadRulesConfigModel()
            : this(false, new ActionDuplicateItems(), TypeCinema.AllType, Grade.AnyGrade)
        {
        }

        public BaseLoadRulesConfigModel(bool deleteGrade, ActionDuplicateItems actionsWithDuplicates, TypeCinema typeCinema, Grade moreGrade)
        {
            DeleteGrade = deleteGrade;
            ActionsWithDuplicates = actionsWithDuplicates;
            TypeCinemaLoad = typeCinema;
            MoreGrade = moreGrade;
        }

        public bool DeleteGrade { get; private set; } = false;

        public ActionDuplicateItems ActionsWithDuplicates { get; private set; } = new ActionDuplicateItems();

        public TypeCinema TypeCinemaLoad { get; private set; } = TypeCinema.AllType;

        public Grade MoreGrade { get; private set; } = Grade.AnyGrade;
    }
}
