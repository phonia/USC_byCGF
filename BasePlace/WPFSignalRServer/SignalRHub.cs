using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using SignalCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFServer
{
    /// <summary>
    /// Used by OWIN's startup process. 
    /// </summary>
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    /// <summary>
    /// Echoes messages sent using the Send message by calling the
    /// addMessage method on the client. Also reports to the console
    /// when clients connect and disconnect.
    /// 客户端方法：AddFailureMessage（String str);
    /// UpdateContacts(list<userList> users);
    /// Addmessage(string username,string message);
    /// AddNotice(string username,publicmessage notice);
    /// AddRecord(string username,Record )
    /// 
    /// </summary>
    public class MyHub : Hub
    {
        public static List<UserInfo> _userList = Data.InitUserInfo();
        public static List<PrivateMessage> _privateMessage = new List<PrivateMessage>();
        public static List<publicMessage> _publicMessage = new List<publicMessage>();
        private static readonly object _lock = new object();

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if (_userList.Any(it => it.ContextId == Context.ConnectionId))
            {
                _userList.Where(it => it.ContextId == Context.ConnectionId).Single().OnLine = false;
            }
            return base.OnDisconnected(stopCalled);
        }

        public void Login(String userName, String userPwd)
        {
            if (_userList.Any(it => it.UserName.Equals(userName) && it.UserPwd.Equals(userPwd) && !it.OnLine))
            {
                var user = _userList.Where(it => it.UserName.Equals(userName)).Single();
                user.OnLine = true;
                user.ContextId = Context.ConnectionId;
                Clients.All.UpdateContacts(_userList);//客服端注册方法
            }
            else
            {
                Clients.Client(Context.ConnectionId).AddFailureMessage("登录失败");//客户端注册方法
            }
        }

        public void Logout(String userName)
        {
            if (_userList.Any(it => it.ContextId == Context.ConnectionId))
            {
                _userList.Where(it => it.ContextId == Context.ConnectionId).Single().OnLine = false;
            }
            Clients.All.UpdateContacts(_userList);//客户端注册方法
        }

        public void PrivateSend(String userName, String message, MessageType messageType)
        {
            var from = _userList.Where(it => it.ContextId == Context.ConnectionId).Single();
            var to = _userList.Where(it => it.UserName == userName).SingleOrDefault();
            if (to != null)
            {
                Record record = new Record() { DateTime = DateTime.Now, Message = message, Name = from.UserName, MessageType = messageType };
                if (to.OnLine)
                {
                    Clients.Client(from.ContextId).AddRecord(from.UserName, record);//客户端注册方法
                    Clients.Client(to.ContextId).AddRecord(from.UserName, record);//客户端注册方法
                }
                else
                {
                    Clients.Client(from.ContextId).AddRecord(from.UserName, record);//客户端注册方法
                    //Clients.Client(from.ContextId).Addmessage(from.UserName, "用户不在线");//客户端注册方法
                }

                //记录聊天信息
                if (_privateMessage.Any(it => (it.From.Equals(from.UserName) && it.To.Equals(to.UserName)) ||
                    (it.To.Equals(from.UserName) && it.From.Equals(to.UserName))))
                {
                    _privateMessage.Where(it => (it.From.Equals(from.UserName) && it.To.Equals(to.UserName)) ||
                    (it.To.Equals(from.UserName) && it.From.Equals(to.UserName)))
                        .Single()
                        .Records
                        .Add(record);
                }
                else
                {
                    _privateMessage.Add(new PrivateMessage()
                    {
                        From = from.UserName,
                        To = to.UserName,
                        Records = new List<Record>() {
                                record
                            }
                    });
                }

            }
            else
            {
                Clients.Client(from.ContextId).Addmessage(userName, "用户：" + userName + "不存在");//客户端注册方法
            }
        }

        public void PublicSend(String group, bool isComment, String criticised, Guid id,String keyWord, String message, MessageType messageType)
        {
            var from = _userList.Where(it => it.ContextId == Context.ConnectionId).SingleOrDefault();
            if (from == null) return;
            if (isComment)
            {
                publicMessage notice = _publicMessage.Where(it => it.Id.Equals(id)).SingleOrDefault();
                if (notice == null) Clients.Client(Context.ConnectionId).AddFailureMessage(message);//客户端注册方法
                notice.Comments.Add(message);
                //GetContactRecord(group);

                foreach (var node in _userList)
                {
                    if (node.IsGroup(group) && node.OnLine)
                    {
                        Clients.Client(node.ContextId).AddNotice(from.UserName, notice);//客户端注册方法
                    }
                }
            }
            else
            {
                publicMessage notice = new publicMessage()
                {
                    Id = System.Guid.NewGuid(),
                    Belongs = group,
                    DateTime = DateTime.Now,
                    From = from.UserName,
                    Message = message,
                    KeyWord = keyWord,
                    MessageType = messageType,
                    Comments = new List<string>() { }
                };
                foreach (var node in _userList)
                {
                    if (node.IsGroup(group) && node.OnLine)
                    {
                        Clients.Client(node.ContextId).AddNotice(from.UserName, notice);//客户端注册方法
                    }
                }
                _publicMessage.Add(notice);
            }
        }

        public void GetContactRecord(String from, String to)
        {
            if (_privateMessage != null)
            {
                PrivateMessage pm = _privateMessage.Where(it => (it.From.Equals(from) && it.To.Equals(to))
                    || (it.From.Equals(to) && it.To.Equals(from))
                    )
                    .SingleOrDefault();
                if (pm != null)
                {
                    foreach (Record node in pm.Records)
                    {
                        Clients.Client(Context.ConnectionId).AddRecord(node.Name, node);//客户端注册方法
                    }
                }
            }
        }

        public void GetContactRecord(String group)
        {
            foreach (var notice in _publicMessage.Where(it => it.Belongs.Equals(group)))
            {
                foreach (var node in _userList)
                {
                    if (node.IsGroup(group) && node.OnLine)
                    {
                        Clients.Client(node.ContextId).AddNotice(node.UserName, notice);//客户端注册方法
                    }
                }
            }
        }
    }
}
