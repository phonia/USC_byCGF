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
    /// PLeftMessageBoxUControl.xaml 的交互逻辑
    /// </summary>
    public partial class PLeftMessageBoxUControl : UserControl
    {
        private String Group;
        public Guid Id { get; set; }
        public Action<System.Guid> Comment { get; set; }

        public PLeftMessageBoxUControl()
        {
            InitializeComponent();
            this.CommentBtn.Click += CommentBtn_Click;
        }

        void CommentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Comment != null)
                Comment(Id);
        }

        internal void UpdateListBox(List<string> list)
        {
            if (this.CommentsListBox.Items != null)
                this.CommentsListBox.Items.Clear();
            if (list == null || list.Count <= 0)
            {
                this.CommentsListBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.CommentsListBox.Visibility = Visibility.Visible;
                foreach (var node in list)
                {
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.Content = node.ToString();
                    this.CommentsListBox.Items.Add(lbi);
                }
            }
        }

        public void Init(string group, List<string> list, DateTime dateTime, string userName, Guid guid, string messages)
        {
            this.UserNameLable.Content = userName;
            this.UserDateTimeLabel.Content = dateTime.ToString("yyyy-MM-dd hh:mm:ss");
            this.UserMessageLable.Content = messages;
            this.Id = guid;
            UpdateListBox(list);
        }

        private void TransmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Teams.DocTransmit docTransmit = new Teams.DocTransmit();
            docTransmit.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            docTransmit.ShowDialog();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }
        
        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            //popCaozuo.IsOpen = true;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            DocManage dm = new DocManage();
            dm.Show();
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        { 
            Teams.Control.HistoryWindow historyWin = new Teams.Control.HistoryWindow();
            historyWin.ShowDialog();
        }
    }
}
