using BookReviewer.Models.IResponse;
using BookReviewer.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Models.Request
{
    public class ESignResponse<TResponse> : CoreResponse<TResponse>, IRecordIDsResponseData
    {
        public ESignResponse()
        {
            this.RecordIDs = new List<int>();
        }

        private List<int> RecordIDs { get; set; }

        public void SetRecordID(int recordId)
        {
            this.RecordIDs.Add(recordId);
        }

        public List<int> GetRecordIDs()
        {
            return this.RecordIDs;
        }
    }
}
