using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;

namespace BookReviewer.Business.Books.Commands.EditBookCommand
{
    public class EditBookCommandParameters : ActionRequest
    {
        public string? BookTitle { get; set; }
        public DateTime? BookReleaseDate { get; set; }
        public string? BookDescription { get; set; }
    }
    public class EditBookCommand : ESignRequest<EditBookCommandParameters, RecordIDResponse>
    {
    }
}
