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
            throw new NotImplementedException();
        }
    }
}
