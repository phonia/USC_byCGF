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

namespace WpfClient.Works
{
    /// <summary>
    /// Works.xaml 的交互逻辑
    /// </summary>
    public partial class Works : UserControl
    {
    
        public Works()
        {
            InitializeComponent();
        }
        

        private void mi_AddNoneDutyWork_Click(object sender, RoutedEventArgs e)
        {
            SysResource.AppStore appStore = new SysResource.AppStore();
            appStore.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            appStore.ShowDialog();
        }
     
        private void tvi_BIM_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //System.Diagnostics.Process.Start(@"BIM\WpfApplication4.exe");

                var process = System.Diagnostics.Process.Start("iexplore.exe", " www.turingit.cn");
                process.WaitForInputIdle();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tvi_GIS_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Application1 app1 = new Application1();
            app1.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            app1.ShowDialog();
        }
    }
}
