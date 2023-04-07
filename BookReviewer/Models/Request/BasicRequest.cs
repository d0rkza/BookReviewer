using BookReviewer.Models.IResponse;
using MediatR;

namespace BookReviewer.Models.Request
{
    public class BasicRequest<TData, TResponse> : BaseRequest<TData>, IRequest<TResponse>, IBaseRequest, IESignRequest where TResponse : IRecordIDsResponseData
    {
        public ESign ESign { get; set; }
    }
}
