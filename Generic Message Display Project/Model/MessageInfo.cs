using System;

namespace MessageSystem.Model
{
    public class MessageInfo
    {
        public string Header { get; }
        public string Message { get; }
        public Guid MessageID { get; }
        public string StackTrace { get; }

        public MessageInfo(string header, string message, Guid messageID, string stackTrace = "")
        {
            Header = header;
            Message = message;
            MessageID = messageID;
            StackTrace = stackTrace;
        }
    }
}