using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SocketDemo.Services;
using SocketDemo.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;

namespace SocketDemo.Hubs
{
    [HubName("lobby")]
    public class LobbyHub : Hub
    {
        // TODO: Use a repository instead of a list
        private static List<ChatUser> _users;

        public LobbyHub()
        {
            if (_users == null)
            {
                _users = new List<ChatUser>();
            }
        }

        public void Join(string name)
        {
            ChatUser currentUser = new ChatUser(name, Context.ConnectionId);
            //_repository.AddUser(currentUser);
            _users.Add(currentUser);

            //var users = _repository.Users.ToList();
            var topic = "Welcome to EmberJS on SignalR";
            //var users = "sample users list";
            Clients.Caller.lobbyEntered(topic, _users);
            Clients.Others.userArrived(currentUser);
        }

        public void SendChat(string msg)
        {
            ChatUser user = _users.Where(x => x.ConnectionId == Context.ConnectionId).FirstOrDefault();
            if (user != null)
            {
                Clients.All.chatSent(user.Name, msg);
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            //_repository.RemoveUser(Context.ConnectionId);
            ChatUser user = _users.Where(x => x.ConnectionId == Context.ConnectionId).FirstOrDefault();
            if (user != null)
            {
                Clients.All.userDisconnected(user);
                _users.RemoveAt(_users.IndexOf(user));
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}