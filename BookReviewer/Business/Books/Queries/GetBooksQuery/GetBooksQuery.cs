using MediatR;

namespace BookReviewer.Business.Books.Queries.GetBooksQuery
{
    public class GetBooksQuery : IRequest<List<GetBooksQueryDTO>>
    {
        public string? BookTitle { get; set; }
        public int? ResultsPerPage { get; set; }
        public int? PageNumber { get; set; }
    }
}
