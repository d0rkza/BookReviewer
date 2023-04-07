using BookReviewer.Models.IResponse;
using BookReviewer.Models.Responses;

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
