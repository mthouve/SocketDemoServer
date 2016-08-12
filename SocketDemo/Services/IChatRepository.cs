using SocketDemo.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocketDemo.Services
{
    public interface IChatRRepository
    {
        ConcurrentDictionary<string, ChatUser> Users { get; set; }

        ChatUser GetUserById(string id);

        void AddUser(ChatUser user);

        ChatUser RemoveUser(string id);
    }
}