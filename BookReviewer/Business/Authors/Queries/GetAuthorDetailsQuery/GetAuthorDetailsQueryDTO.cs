using BookReviewer.Models;

namespace BookReviewer.Business.Authors.Queries.GetAuthorDetailsQuery
{
    public class GetAuthorDetailsQueryDTO
    {
        public string? AuthorName { get; set; }
        public string? AuthorSurname { get; set; }
        public DateTime? AuthorDateOfBirth { get; set; }
        public string? AuthorBio { get; set; }

        public List<Book> Books { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
