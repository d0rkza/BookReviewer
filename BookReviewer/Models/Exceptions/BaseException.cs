using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Models.Exceptions
{
    public class BaseException : Exception
    {
        private Dictionary<string, string> parameters;

        public bool Handeled { get; set; } = false;


        public string Code { get; set; }

        public string Text { get; set; }

        public string Details { get; set; }

        public override string Message => Code + (string.IsNullOrEmpty(Text) ? string.Empty : ("; " + Text));

        public Dictionary<string, string> Parameters
        {
            get
            {
                return parameters;
            }
            set
            {
                parameters = value;
            }
        }

        public BaseException(string code, string message)
            : base(message)
        {
            Code = code;
            Text = message;
        }

        public BaseException(string code, string message, string details)
            : this(code, message)
        {
            Details = details;
        }

        public BaseException(string code)
            : this(code, string.Empty)
        {
            Code = code;
        }

        public BaseException(string code, Dictionary<string, string> parameters)
            : this(code)
        {
            Code = code;
            this.parameters = parameters;
        }
    }
}
