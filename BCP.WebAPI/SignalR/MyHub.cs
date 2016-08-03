using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;

namespace BCP.WebAPI.SignalR
{
    public class MyHub:Hub
    {
        public override System.Threading.Tasks.Task OnConnected()
        {
            Clients.Client(Context.ConnectionId).AddMessage("Hub:","登录测试！");
            return base.OnConnected();
        }

        public void Subscribe(string customerId)
        {
            Groups.Add(Context.ConnectionId, customerId);
        }

        public void Unsubscribe(string customerId)
        {
            Groups.Remove(Context.ConnectionId, customerId);
        }
    }
}