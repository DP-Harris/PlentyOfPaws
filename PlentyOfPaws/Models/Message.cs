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
        public DateTime MessageTimestamp { get; set; }
        // Get the chat ID that the message relates to
        public int ChatID { get; set; }
    }
}
