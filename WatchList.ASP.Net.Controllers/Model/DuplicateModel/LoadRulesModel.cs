using WatchList.ASP.Net.Controllers.Enums;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;

namespace WatchList.ASP.Net.Controllers.Model.DuplicateModel
{
    public class LoadRulesModel
    {
        public bool DeleteGrade { get; private set; } = false;

        public bool IsUpdateDuplicateItems { get; set; } = true;

        public bool IsCaseSensitive { get; set; } = true;

        public Grades Grades { get; set; } = Grades.AnyGrade;

        public Types Types { get; set; } = Types.AllType;

        public LoadRulesConfigModel GetLoadRulesConfigModel()
        {
            var duplicateLoadRulesModel = new DuplicateLoadRulesModel(IsUpdateDuplicateItems, IsCaseSensitive).GetDuplicateLoadRules();
            var actionsWithDuplicate = new ActionDuplicateItems(true, duplicateLoadRulesModel);
            return new LoadRulesConfigModel(DeleteGrade, actionsWithDuplicate, GetTypeCinema, GetGrade);
        }

        private TypeCinema GetTypeCinema
            => Types switch
            {
                Types.AllType => TypeCinema.AllType,
                Types.Movie => TypeCinema.Movie,
                Types.Series => TypeCinema.Series,
                Types.Anime => TypeCinema.Anime,
                Types.Cartoon => TypeCinema.Cartoon,
                _ => TypeCinema.AllType,
            };

        private Grade GetGrade
            => Grades switch
            {
                Grades.One => Grade.One,
                Grades.Two => Grade.Two,
                Grades.Three => Grade.Three,
                Grades.Four => Grade.Four,
                Grades.Five => Grade.Five,
                Grades.Six => Grade.Six,
                Grades.Seven => Grade.Seven,
                Grades.Eight => Grade.Eight,
                Grades.Nine => Grade.Nine,
                Grades.Ten => Grade.Ten,
                _ => Grade.AnyGrade,
            };
    }
}
