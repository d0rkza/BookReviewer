using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Models.Responses
{
    public class RecordIDResponseData
    {
        public int RecordId { get; set; }

        public RecordIDResponseData(int recordId)
        {
            RecordId = recordId;
        }

        public RecordIDResponseData()
        {
        }

        public List<int> GetRecordIDs()
        {
            return new List<int> { RecordId };
        }
    }
}
