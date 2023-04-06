using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Models.Request
{
    public class ActionRequest : QueryDataById<int>
    {
        //public string CurrentStateCode { get; set; }

        //[Required]
        //public string ActionCode { get; set; }

        //[Required]
        //public string RecordTypeCode { get; set; }
    }
}
