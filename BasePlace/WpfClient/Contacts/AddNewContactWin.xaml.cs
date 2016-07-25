using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfClient.Contacts
{
    /// <summary>
    /// AddNewContactWin.xaml 的交互逻辑
    /// </summary>
    public partial class AddNewContactWin : Window
    {
        public List<string> userGroupList = new List<string>();

        public AddNewContactWin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载用户分组
        /// </summary>
        void LoadingUserGroups()
        {
            cbb_Groups.ItemsSource = userGroupList;
        }

        private void cbb_Groups_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingUserGroups();
        }

        private void btn_searchUser_Click(object sender, RoutedEventArgs e)
        {
            if (tb_userId.Text.Trim() != "")
            {
                string userId = tb_userId.Text.Trim();
                foreach (SignalCore.UserInfo item in Login.LoginWin.userList)
                {
                    if (userId == item.UserAccount)
                    {
                        tb_userName.Text = item.UserName;
                        return;
                    }
                    else
                    {
                        tb_userName.Text = "";
                    }
                } 
            }
            else
            {
                MessageBox.Show("请输入要搜索的用户ID");
            }
        }

        public string GroupName = "";
        public string userName = "";
        private void btn_AddNewContact_Click(object sender, RoutedEventArgs e)
        {
            if (tb_userName.Text.Trim() != "")
            {
                if (cbb_Groups.SelectedItem != null)
                {
                    GroupName = cbb_Groups.SelectedItem.ToString();
                    userName = tb_userName.Text.Trim();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("请选择联系人分组");
                }
            }
            else
            {
                MessageBox.Show("找不到该联系人");
            }
        }
    }
}
