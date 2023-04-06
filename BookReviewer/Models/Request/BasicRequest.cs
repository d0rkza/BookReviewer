using BookReviewer.Models.IResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Models.Request
{
    public class BasicRequest<TData, TResponse> : BaseRequest<TData>, IRequest<TResponse>, IBaseRequest, IESignRequest where TResponse : IRecordIDsResponseData
    {
        public ESign ESign { get; set; }
    }
}
