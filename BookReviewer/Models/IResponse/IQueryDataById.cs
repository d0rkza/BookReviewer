namespace BookReviewer.Models.IResponse
{
    public interface IQueryDataById<TId>
    {
        void SetId(TId id);

        TId GetId();
    }
}
