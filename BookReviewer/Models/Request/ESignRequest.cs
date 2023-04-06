using BookReviewer.Models.IResponse;
using MediatR;

namespace BookReviewer.Models.Request
{
    public class ESignRequest<TData, TResponse> : BaseRequest<TData>, IRequest<TResponse>, IESignRequest where TResponse : IRecordIDsResponseData
    {
        public ESign ESign { get; set; }
    }
}
