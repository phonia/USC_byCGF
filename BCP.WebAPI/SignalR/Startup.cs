using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;

namespace BCP.WebAPI.SignalR
{
    [assembly: OwinStartup(typeof(BCP.WebAPI.SignalR.Startup))]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}