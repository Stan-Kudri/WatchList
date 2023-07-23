using Microsoft.EntityFrameworkCore;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Repository.Db;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public class CaseSensitivityLoadRule : ILoadRule
    {
        private readonly bool _isCaseSensitive;

        private readonly WatchCinemaDbContext _dbContext;

        public CaseSensitivityLoadRule(WatchCinemaDbContext db, bool isCaseSensitive)
        {
            _dbContext = db;
            _isCaseSensitive = isCaseSensitive;
        }

        public IReadOnlyCollection<WatchItem> Apply(IReadOnlyCollection<WatchItem> items)
        {
            if (!_isCaseSensitive)
            {
                return items;
            }

            var titles = items.Select(e => e.TitleNormalized).ToHashSet();
            var duplicateRows = _dbContext.WatchItem.AsNoTracking()
                .Where(e => titles.Contains(e.TitleNormalized))
                .Select(e => e.TitleNormalized);
            titles.ExceptWith(duplicateRows);
            return items.Where(e => !titles.Contains(e.TitleNormalized)).ToList();
        }
    }
}
