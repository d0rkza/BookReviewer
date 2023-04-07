using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;

namespace BookReviewer.Business.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommand : ESignRequest<ActionRequest, RecordIDResponse>
    {
    }
}
