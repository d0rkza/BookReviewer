namespace BookReviewer.Models.Request
{
    public class BaseRequest<TData>
    {
        public TData Data { get; set;}
    }
}
