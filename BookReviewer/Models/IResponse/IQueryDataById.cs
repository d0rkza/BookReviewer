using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Models.IResponse
{
    public interface IQueryDataById<TId>
    {
        void SetId(TId id);

        TId GetId();
    }
}
