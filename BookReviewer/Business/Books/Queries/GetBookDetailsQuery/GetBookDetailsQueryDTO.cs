using BookReviewer.Models;

namespace BookReviewer.Business.Books.Queries.GetBookDetailsQuery
{
    public class GetBookDetailsQueryDTO
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public DateTime BookReleaseDate { get; set; }

        public List<Author> Authors { get; set; }

        public List<Genre> Genres { get; set; }
    }
}
