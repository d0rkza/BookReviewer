using BookReviewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Authors.Queries.GetAuthorsQuery
{
    public class GetAuthorsQueryDTO
    {
        public string? AuthorName { get; set; }
        public string? AuthorSurname { get; set; }
        public DateTime? AuthorDateOfBirth { get; set; }
        public string? AuthorBio { get; set; }
    }
}
