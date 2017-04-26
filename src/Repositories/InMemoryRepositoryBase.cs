using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendBot.Repositories
{
    public abstract class InMemoryRepositoryBase<T> : IRepository<T>
    {
        public PagedResult<T> RetrievePage(int pageNumber, int pageSize, Func<T, bool> predicate = default(Func<T, bool>))
        {
            var items = this.Find(predicate);

            return new PagedResult<T>
            {
                Items = items.Skip(pageSize * (pageNumber - 1)).Take(pageSize),
                TotalCount = items.Count()
            };
        }

        public abstract T GetByName(string name);

        public abstract IEnumerable<T> Find(Func<T, bool> predicate);

        public abstract IEnumerable<T> FindAll();
    }
}