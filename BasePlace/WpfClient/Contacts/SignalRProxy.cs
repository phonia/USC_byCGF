using Microsoft.AspNet.SignalR.Client;
using SignalCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.Contacts
{
    public class SignalRProxy:IDisposable
    {
        private String _serverURI = @"http://localhost:8080";
        private HubConnection _hubConnection = null;
        private IHubProxy _hubProxy = null;
        public Action<String> ReceviceFialureMessage { get; set; }
        public Action<List<UserInfo>> UpdateContacts { get; set; }
        public Action<String, String> ReceviceMessage { get; set; }
        public Action<String, publicMessage> ReceviceNotice { get; set; }
        public Action<String, Record> ReceviceRecord { get; set; }

        public bool Login(String userName, string userPwd)
        {
            try
            {
                _hubProxy.Invoke("Login", userName, userPwd);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Logout(string userName)
        {
            _hubProxy.Invoke("Logout", userName);
        }

        public void PrivateSend(String To,String message,MessageType messageType)
        {
            if (_hubProxy != null && _hubConnection.State == ConnectionState.Connected)
                _hubProxy.Invoke("PrivateSend", To, message, messageType);
        }
        /// <summary>
        /// isCommnet=true则criticised与id不能为空
        /// </summary>
        /// <param name="group"></param>
        /// <param name="isComment"></param>
        /// <param name="criticised"></param>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        public void PublicSend(string group,bool isComment,String criticised,Guid id,String keyWord,String message,MessageType messageType )
        {
            if (_hubProxy != null && _hubConnection.State == ConnectionState.Connected)
                _hubProxy.Invoke("PublicSend",
                    group, isComment, criticised, id,keyWord, message, messageType);
        }

        public void GetContactRecord(String from, String to)
        {
            if (_hubProxy != null && _hubConnection.State == ConnectionState.Connected)
                _hubProxy.Invoke("GetContactRecord",
                    from, to);
        }

        public void GetContactRecord(String group)
        {
            if (_hubProxy != null && _hubConnection.State == ConnectionState.Connected)
                _hubProxy.Invoke("GetContactRecord",
                    group);
        }

        public async void ConnectAsync()
        {
            if (_hubConnection != null && _hubConnection.State != ConnectionState.Disconnected) return;

            _hubConnection = new HubConnection(_serverURI);
            _hubProxy = _hubConnection.CreateHubProxy("MyHub");
            /*
             * 注册客户端方法
             * ***/
            _hubProxy.On<String>("AddFailureMessage",(message)=>{
                if (ReceviceFialureMessage != null)
                    ReceviceFialureMessage(message);
            });
            _hubProxy.On<List<UserInfo>>("UpdateContacts", (userlist) =>
            {
                if (UpdateContacts != null)
                    UpdateContacts(userlist);
            });
            _hubProxy.On<String,String>("Addmessage", (username,message) =>
            {
                if (ReceviceMessage != null)
                    ReceviceMessage(username, message);
            });
            _hubProxy.On<String,publicMessage>("AddNotice", (username,notice) =>
            {
                if (ReceviceNotice != null)
                    ReceviceNotice(username, notice);
            });
            _hubProxy.On<String,Record>("AddRecord", (username,record) =>
            {
                if (ReceviceRecord != null)
                    ReceviceRecord(username, record);
            });
            try
            {
                await _hubConnection.Start();
            }
            catch (Exception ex)
            {

            }
        }

        public void Dispose()
        {
            if (this._hubConnection != null)
            {
                if (_hubConnection.State != ConnectionState.Disconnected) this._hubConnection.Stop();
                this._hubConnection.Dispose();
            }
        }
    }
}
