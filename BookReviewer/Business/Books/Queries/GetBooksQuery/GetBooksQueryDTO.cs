namespace BookReviewer.Business.Books.Queries.GetBooksQuery
{
    public class GetBooksQueryDTO
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public DateTime BookReleaseDate { get; set; }
    }
}
