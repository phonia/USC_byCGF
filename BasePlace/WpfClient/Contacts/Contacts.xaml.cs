﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfClient.Contacts
{
    /// <summary>
    /// Contacts.xaml 的交互逻辑
    /// </summary>
    public partial class Contacts : UserControl
    {
        public Contacts()
        {
            InitializeComponent();
        }

        private void mi_AddGroup_Click(object sender, RoutedEventArgs e)
        {
            AddNewGroupWin ang_win = new AddNewGroupWin();
            ang_win.ShowDialog();
            if (ang_win.NewGroupName != "")
            {
                TreeViewItem tvi = new TreeViewItem();
                tvi.Header = ang_win.NewGroupName;
                tv_Contacts.Items.Add(tvi);
            }

        }

        private void mi_AddContact_Click(object sender, RoutedEventArgs e)
        {
            //获取当前用户分组
            List<string> list_tvi = new List<string>();
            foreach (var item in tv_Contacts.Items)
            {
                list_tvi.Add((item as TreeViewItem).Header.ToString());
            }

            
            AddNewContactWin anc_win = new AddNewContactWin();
            anc_win.userGroupList = list_tvi;
            anc_win.ShowDialog();

            foreach (TreeViewItem item in tv_Contacts.Items)
            {
                if (anc_win.GroupName == item.Header.ToString())
                {
                    TreeViewItem tvi = new TreeViewItem();
                    tvi.Header = anc_win.userName;
                    item.Items.Add(tvi);
                    return;
                }

            }
        }

        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PrivateDialog pd1 = new PrivateDialog();
            pd1.SignalRProxy = new SignalRProxy();
            pd1.SignalRProxy.ConnectAsync();
            pd1.To = (sender as TreeViewItem).Header.ToString();
            pd1.Self =MainClient.currentUser.UserName;

            PrivateDialog pd2 = new PrivateDialog();
            pd2.To = MainClient.currentUser.UserName;
            pd2.Self = (sender as TreeViewItem).Header.ToString();
            //pd2.SignalRProxy = new SignalRProxy();
            pd2.SignalRProxy.ConnectAsync();

            pd1.Closed += (sen, er) => {
                pd1.SignalRProxy.Logout(MainClient.currentUser.UserName);
                pd1.SignalRProxy.Dispose();
            };
            pd2.Closed += (sen, er) => {
                pd2.SignalRProxy.Logout((sender as TreeViewItem).Header.ToString());
                pd2.SignalRProxy.Dispose();
            };

            pd1.Init();
            pd2.Init();

            System.Threading.Thread.Sleep(1000);

            string pwd1 = "";
            string pwd2 = "";
            foreach (SignalCore.UserInfo item in Login.LoginWin.userList)
            {
                if (item.UserName == MainClient.currentUser.UserName)
                {
                    pwd1 = item.UserPwd;
                }
                if (item.UserName == (sender as TreeViewItem).Header.ToString())
                {
                    pwd2 = item.UserPwd;
                }
            }

            if (pd1.SignalRProxy.Login(MainClient.currentUser.UserName, pwd1))
            {
                pd1.SignalRProxy.GetContactRecord(MainClient.currentUser.UserName, (sender as TreeViewItem).Header.ToString());
                pd1.Show();
            }
            if (pd2.SignalRProxy.Login((sender as TreeViewItem).Header.ToString(), pwd2))
            {
                pd2.SignalRProxy.GetContactRecord((sender as TreeViewItem).Header.ToString(), MainClient.currentUser.UserName);
                pd2.Show();
            }
        }
    }
}