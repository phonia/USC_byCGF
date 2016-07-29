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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfClient.Contacts
{
    /// <summary>
    /// MessageBoxUControl.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxUControl : UserControl
    {
        public MessageBoxUControl()
        {
            InitializeComponent();
        }

        //internal void Init(DialogMessage dialogMessage)
        //{
        //    this.UserNameDockPanel.HorizontalAlignment = dialogMessage.IsSelf ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        //    this.UserNameLabel.Content = dialogMessage.UserName+":";
        //    this.MessageDockPanel.HorizontalAlignment = dialogMessage.IsSelf ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        //    this.MessagesLabel.Text =dialogMessage.IsSelf?dialogMessage.Messages.ToString():dialogMessage.Messages.ToString();
        //}
    }
}
