using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalCore
{
    public class UserInfo
    {
        public String UserAccount { set; get; }
        public String UserName { get; set; }
        public String UserPwd { get; set; }
        public Boolean OnLine { get; set; }
        public String Department { get; set; }
        public String ContextId { get; set; }

        public bool IsGroup(string group)
        {
            if (Department.Equals(group)) return true;
            else return false;
        }
    }

    public enum MessageType
    {
        Text,doc
    }


    #region private
    public class Record
    {
        public String Name { get; set; }
        public String Message { get; set; }
        public DateTime DateTime { get; set; }
        public MessageType MessageType { get; set; }
    }

    public class PrivateMessage
    {
        public String From { get; set; }
        public String To { get; set; }
        public List<Record> Records { get; set; }
    }
    #endregion


    #region public
    /// <summary>
    /// 重写20160413
    /// </summary>
    public class publicMessage
    {
        public Guid Id { get; set; }
        public String Belongs { get; set; }
        public String From { get; set; }
        public DateTime DateTime { get; set; }
        public String Message { get; set; }
        public String KeyWord { get; set; }
        public List<String> Comments { get; set; }
        public MessageType MessageType { get; set; }
    }
    #endregion

}
