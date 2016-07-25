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
using Orbifold.Graphite;
using System.Xml.Linq;
using System.IO;
using System.Globalization;


namespace WpfClient.Teams.Control
{
    /// <summary>
    /// HistoryWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryWindow : Window
    {
        GraphCanvas graphite = new GraphCanvas();
        public HistoryWindow()
        {
            InitializeComponent();
            RootGrid.Children.Add(graphite);
            var n0 = new Node() { Title = "邵金麟", InitialPosition = new Point(140, 20) };
            var n01 = new Node() { Title = "李伯生", InitialPosition = new Point(120, 40) };
            var n02 = new Node() { Title = "张伯伦", InitialPosition = new Point(160, 40) };
            var n011 = new Node() { Title = "王丙乾", InitialPosition = new Point(100, 60) };
            var n012 = new Node() { Title = "陈浩然", InitialPosition = new Point(180, 60) };
            var n0111 = new Node() { Title = "索罗斯", InitialPosition = new Point(80, 80) };
            var n0121 = new Node() { Title = "金正恩", InitialPosition = new Point(200, 80) };
            var n0122 = new Node() { Title = "胡宗南", InitialPosition = new Point(100, 100) };
            var n01221 = new Node() { Title = "姜波", InitialPosition = new Point(190, 100) };

            graphite.AddNode(n0);
            graphite.AddNode(n01);
            graphite.AddNode(n02);
            graphite.AddNode(n011);
            graphite.AddNode(n012);
            graphite.AddNode(n0111);
            graphite.AddNode(n0121);
            graphite.AddNode(n0122);
            graphite.AddNode(n01221);
            graphite.AddEdge(n0, n01);
            graphite.AddEdge(n0, n02);
            graphite.AddEdge(n01, n011);
            graphite.AddEdge(n01, n012);
            graphite.AddEdge(n011, n0111);
            graphite.AddEdge(n012, n0121);
            graphite.AddEdge(n012, n0122);
            graphite.AddEdge(n0122, n01221);


        }
      
    }
}
