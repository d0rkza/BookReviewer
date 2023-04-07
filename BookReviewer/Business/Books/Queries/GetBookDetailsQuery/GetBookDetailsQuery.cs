﻿using MediatR;

namespace BookReviewer.Business.Books.Queries.GetBookDetailsQuery
{
    public class GetBookDetailsQuery : IRequest<GetBookDetailsQueryDTO>
    {
        public int? BookId { get; set; }
    }
}
