using BookReviewer.Models.IResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Models.Responses
{
    public class RecordIDResponse : CoreResponse<RecordIDResponseData>, IRecordIDsResponseData
    {
        public RecordIDResponse(int recordId)
        {
            base.Data = new RecordIDResponseData(recordId);
        }

        public RecordIDResponse()
        {
            base.Data = new RecordIDResponseData();
        }

        public void SetId(int recordId)
        {
            base.Data.RecordId = recordId;
        }

        public List<int> GetRecordIDs()
        {
            return new List<int> { base.Data.RecordId };
        }
    }
}
