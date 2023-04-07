namespace BookReviewer.Models.IResponse
{
    public class Message
    {
        public MessageType Type { get; set; }

        public string Code { get; set; }

        public string Text { get; set; }

        public string Details { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}
