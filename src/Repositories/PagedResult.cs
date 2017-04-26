using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuisBot.Repositories
{
    public class PagedResult<R>
    {
        public IEnumerable<R> Items { get; set; }

        public int TotalCount { get; set; }
    }
}