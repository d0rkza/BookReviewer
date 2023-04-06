using MediatR;

namespace BookReviewer.Business.Authors.Queries.GetAuthorDetailsQuery
{
    public class GetAuthorDetailsQuery : IRequest<GetAuthorDetailsQueryDTO>
    {
        public int AuthorId { get; set; }
    }
}
