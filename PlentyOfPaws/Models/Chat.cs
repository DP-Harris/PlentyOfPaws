using System;
using System.Collections.Generic;
using System.Text;

namespace PlentyOfPaws.Models
{
    public class Chat
    {

        public static List<Chat> UserChats = new List<Chat>();

        // Get the chat ID of the chat
        public int ChatID { get; set; }
        // Get the timestamp of the last message that was sent
        public DateTime ChatTimestamp { get; set; }
        // Get the UserIDs of the users involved in the chat
        public int UserIDA { get; set; }
        public int UserIDB { get; set; }

        public void AddChatToList(Chat UserChat)
        {
            UserChats.Add(UserChat);
        }
    }
}
