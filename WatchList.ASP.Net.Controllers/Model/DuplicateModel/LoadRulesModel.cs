using System.ComponentModel.DataAnnotations;
using WatchList.Core.Enums;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;

namespace WatchList.ASP.Net.Controllers.Model.DuplicateModel
{
    public class LoadRulesModel
    {
        [Required]
        public bool DeleteGrade { get; set; } = false;

        [Required]
        public bool IsUpdateDuplicateItems { get; set; } = true;

        [Required]
        public bool IsCaseSensitive { get; set; } = true;

        [Required]
        public Grades Grades { get; set; } = Grades.AnyGrade;

        [Required]
        public Types Types { get; set; } = Types.AllType;

        public BaseLoadRulesConfigModel GetLoadRulesConfigModel()
        {
            var duplicateLoadRulesModel = new DuplicateLoadRulesModel(IsUpdateDuplicateItems, IsCaseSensitive).GetDuplicateLoadRules();
            var actionsWithDuplicate = new ActionDuplicateItems(true, duplicateLoadRulesModel);
            return new BaseLoadRulesConfigModel(DeleteGrade, actionsWithDuplicate, TypeCinema.FromValue(Types), Grade.FromValue(Grades));
        }
    }
}
