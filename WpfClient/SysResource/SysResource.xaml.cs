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

namespace WpfClient.SysResource
{
    /// <summary>
    /// SysResource.xaml 的交互逻辑
    /// </summary>
    public partial class SysResource : UserControl
    {
        public SysResource()
        {
            InitializeComponent();
        }

        private void tv_softwarePublish_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ResourcePublish resourcePublish = new ResourcePublish();
            resourcePublish.ShowDialog();
        }

        private void tv_AppSearch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AppStore appStore = new AppStore();
            appStore.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            appStore.ShowDialog();
        }
    }
}
