using WatchList.Core.Enums;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;

namespace WatchList.ASP.Net.Controllers.Model.DuplicateModel
{
    public class LoadRulesModel
    {
        public LoadRulesModel(bool deleteGrade,
                              bool isUpdateDuplicateItems,
                              bool isCaseSensitive,
                              Grades grades,
                              Types types)
        {
            DeleteGrade = deleteGrade;
            IsUpdateDuplicateItems = isUpdateDuplicateItems;
            IsCaseSensitive = isCaseSensitive;
            Grades = grades;
            Types = types;
        }

        public bool DeleteGrade { get; private set; } = false;

        public bool IsUpdateDuplicateItems { get; set; } = true;

        public bool IsCaseSensitive { get; set; } = true;

        public Grades Grades { get; set; } = Grades.AnyGrade;

        public Types Types { get; set; } = Types.AllType;

        public BaseLoadRulesConfigModel GetLoadRulesConfigModel()
        {
            var duplicateLoadRulesModel = new DuplicateLoadRulesModel(IsUpdateDuplicateItems, IsCaseSensitive).GetDuplicateLoadRules();
            var actionsWithDuplicate = new ActionDuplicateItems(true, duplicateLoadRulesModel);
            return new BaseLoadRulesConfigModel(DeleteGrade, actionsWithDuplicate, TypeCinema.FromValue((int)Types), Grade.FromValue((int)Grades));
        }
    }
}
