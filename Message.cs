using System;
using System.Collections.Generic;
using System.Text;

namespace PlentyOfPaws.Models
{
    public class Message
    {
        // Get the content of the message
        public string Content { get; set; }
        // Get the user that sent the message
        public int UserID { get; set; }
        // Get the timestamp that the message was sent
        public struct MessageTimestamp
        {
            public int day { get; set; }
            public int month { get; set; }
            public int year { get; set; }
            public int hour { get; set; }
            public int minute { get; set; }
        }
        // Get the chat ID that the message relates to
        public int ChatID { get; set; }
    }
}
