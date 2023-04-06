using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommand : ESignRequest<ActionRequest, RecordIDResponse>
    {
    }
}
