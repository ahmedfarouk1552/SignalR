using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SingalrChat.Models;
using System.Threading.Tasks;

namespace SingalrChat
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        ChatContext db = new ChatContext();
        public void sendmessage(string name,string mess )
        {
            Clients.All.newmessage(name, mess);
            message m = new message() { name = name, message1 = mess, date = DateTime.Now };
            db.messages.Add(m);
            db.SaveChanges();

            //Clients.All.newmessage(m);




        }

        public override Task OnConnected()
        {
            //string id = Context.ConnectionId;
            return base.OnConnected();  
        }

        public void joingroup(string groupName,string name)
        {
            Groups.Add(Context.ConnectionId, groupName);
            try
            {
                Clients.OthersInGroup(groupName).newmember(name, groupName);
            }
            catch (Exception)
            {

            }
        }

        public void sendtogroup(string groupname, string name, string message)
        {

            try
            {
                Clients.Group(groupname).messagegroup(groupname, name, message);
            }
            catch (Exception)
            {

            }
        }
    }
}