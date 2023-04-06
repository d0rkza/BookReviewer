using BookReviewer.Models.IResponse;
using BookReviewer.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Models.Responses
{
    public class CoreResponse<TData> : ICoreResponse<TData>, IMessageResponse
    {
        private readonly List<Message> messages;

        public TData Data { get; set; }

        public List<Message> Messages => messages;

        public CoreResponse()
        {
            messages = new List<Message>();
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }

        public void AddMessage(BaseException baseException)
        {
            Messages.Add(new Message
            {
                Code = baseException.Code,
                Details = baseException.Details,
                Parameters = baseException.Parameters,
                Text = baseException.Text,
                Type = MessageType.Error
            });
        }

        public void AddErrorMessage(string code, string defaultMessage = null)
        {
            Messages.Add(new Message
            {
                Type = MessageType.Error,
                Code = code,
                Text = defaultMessage
            });
        }

        public bool AnyError()
        {
            return Messages.Where((Message m) => m.Type == MessageType.Error).Any();
        }
    }
}
