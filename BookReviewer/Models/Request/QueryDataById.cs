using BookReviewer.Models.IResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Models.Request
{
    public class QueryDataById<TId> : IQueryDataById<TId>
    {
        private TId id;

        public QueryDataById()
        {
        }

        public QueryDataById(TId id)
        {
            this.id = id;
        }

        public void SetId(TId id)
        {
            this.id = id;
        }

        public TId GetId()
        {
            return this.id;
        }
    }
}
