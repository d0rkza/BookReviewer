using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Models.Request
{
    public class BaseRequest<TData>
    {
        public TData Data { get; set;}
    }
}
