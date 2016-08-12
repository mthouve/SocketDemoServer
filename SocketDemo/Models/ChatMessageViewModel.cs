using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocketDemo.Models
{
    public class ChatMessageViewModel
    {
        public UserViewModel Sender;
        public string Message;

        public ChatMessageViewModel(UserViewModel sender, string message)
        {
            Sender = sender;
            Message = message;
        }
    }
}