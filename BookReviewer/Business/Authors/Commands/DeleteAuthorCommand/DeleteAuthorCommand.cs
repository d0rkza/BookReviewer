using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommand : ESignRequest<ActionRequest, RecordIDResponse>
    {
    }
}