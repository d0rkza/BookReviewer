using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
