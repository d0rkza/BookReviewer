namespace BookReviewer.Models.IResponse
{
    public interface ICoreResponse<TData> : IMessageResponse
    {
        TData Data { get; set; }
    }
}
