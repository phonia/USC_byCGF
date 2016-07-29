using SignalCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalCore
{
    public class Data
    {
        public static List<UserInfo> InitUserInfo()
        {
            List<UserInfo> list = new List<UserInfo>();
            list.Add(new UserInfo { Department = "工程部", OnLine = false, UserName = "工人", UserPwd = "工人" });
            list.Add(new UserInfo { Department = "市场部", OnLine = false,UserAccount="xiaoshou", UserName = "销售", UserPwd = "xiaoshou" });
            list.Add(new UserInfo { Department = "市场部", OnLine = false, UserName = "阿发", UserPwd = "阿发" });
            list.Add(new UserInfo { Department = "市场部", OnLine = false, UserName = "邵工", UserPwd = "邵工" });
            list.Add(new UserInfo { Department = "技术部", OnLine = false,UserAccount="zhangsan", UserName = "张三", UserPwd = "zhangsan" });
            list.Add(new UserInfo { Department = "财务部", OnLine = false,UserAccount="lisi", UserName = "李四", UserPwd = "lisi" });
            list.Add(new UserInfo { Department = "合约部", OnLine = false,UserAccount="wangwu", UserName = "王五", UserPwd = "wangwu" });
            list.Add(new UserInfo { Department = "财务部", OnLine = false, UserAccount = "limochou", UserName = "李莫愁", UserPwd = "limochou" });
            list.Add(new UserInfo { Department = "合约部", OnLine = false, UserAccount = "lina", UserName = "李娜", UserPwd = "lina" });
            list.Add(new UserInfo { Department = "技术部", OnLine = false, UserAccount = "zhaobingru", UserName = "赵冰茹", UserPwd = "zhaobingru" });
            list.Add(new UserInfo { Department = "财务部", OnLine = false, UserAccount = "fengxiaoxin", UserName = "冯小新", UserPwd = "fengxiaoxin" });
            list.Add(new UserInfo { Department = "合约部", OnLine = false, UserAccount = "mawenru", UserName = "马文儒", UserPwd = "mawenru" });
            return list;
        }

   

        public static List<String> InitDepartment()
        {
            List<String> Departmens = new List<string>();
            Departmens.Add("工程部");
            Departmens.Add("市场部");
            Departmens.Add("技术部");
            Departmens.Add("合约部");
            Departmens.Add("财务部");
            return Departmens;
        }

        //public static List<String> InitOrganization()
        //{
        //    List<String> Organizations = new List<string>();
        //    Organizations.Add("广州市图之灵计算机技术有限公司");
        //    Organizations.Add("广东省公路建设有限公司江罗分公司");
        //    Organizations.Add("图之灵科技");
        //    return Organizations;
        //}

        public static List<OrgInfo> InitOrganization()
        {
            List<OrgInfo> Organizations = new List<OrgInfo>();
            OrgInfo orginfo1 = new OrgInfo();
            orginfo1.OrgName = "广州市图之灵计算机技术有限公司";
            orginfo1.OrgCode= "1001";
            Organizations.Add(orginfo1);

            OrgInfo orginfo2 = new OrgInfo();
            orginfo2.OrgName = "广东省公路建设有限公司江罗分公司";
            orginfo2.OrgCode = "1000";
            Organizations.Add(orginfo2);

            OrgInfo orginfo3 = new OrgInfo();
            orginfo3.OrgName = "图之灵科技";
            orginfo3.OrgCode = "10011";
            Organizations.Add(orginfo3);
            return Organizations;
        }
    }
}
