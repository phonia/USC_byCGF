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
using WpfClient.Teams;

namespace WpfClient.Teams.Control
{
    /// <summary>
    /// Input.xaml 的交互逻辑
    /// </summary>
    public partial class Input : UserControl
    {
        public Input()
        {
            InitializeComponent();
        }
        int clickCount = 0;
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public RoutedEvent Click;

        private void input_Click(object sender, RoutedEventArgs e)
        {
            Button bt =sender as Button;
            if (bt != null)
            {
                if ((string)bt.Content == "+")
                {
                    if (clickCount == 0)
                    {
                        clickCount += 1;
                        this.Height = 160;
                        wrap1.Visibility = Visibility.Visible;
                        wrap2.Visibility = Visibility.Visible;
                        textbox.IsEnabled = false;
                        this.RenderTransform = new TranslateTransform(0, -120);
                    }

                    else
                    {
                        clickCount = 0;
                        textbox.IsEnabled = true;
                        wrap1.Visibility = Visibility.Hidden;
                        wrap2.Visibility = Visibility.Hidden;
                       RaiseEvent(e);
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox ttb = sender as TextBox;
            string btname = input.Content.ToString();
            if (btname == "+")
            {
                if (ttb.Text != "")
                {
                    input.FontSize = 10;
                    input.Content = "发送";
                    text = ttb.Text;
                }
            }
            else if (btname == "发送")
            {
                if (ttb.Text == "")
                {
                    input.FontSize = 18;
                    input.Content = "+";
                }
            }
            
        }

        private void docButton_Click(object sender, RoutedEventArgs e)
        {
            DocPublish k = new DocPublish();
            k.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WpfClient.Teams.Control.Task trs = new Task();
            trs.ShowDialog();
        }
    }
}
