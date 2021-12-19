using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SingalrChat.Models;

namespace SingalrChat
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        ChatContext db = new ChatContext();
        public void sendmessage(string name,string mess)
        {
            Clients.All.newmessage(name, mess);

            message m =new message() { name=name,message1=mess,date=DateTime.Now}; 
            db.messages.Add(m);
            db.SaveChanges();
            
        }
    }
}