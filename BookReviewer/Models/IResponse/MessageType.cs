using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Models.IResponse
{
    public enum MessageType
    {
        Info,
        Success,
        Error,
        Warning,
        Question,
        Label,
        InlineWarning,
        DevInfo,
        DevWarning,
        DevError
    }
}
