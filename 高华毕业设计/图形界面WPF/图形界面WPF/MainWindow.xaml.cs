using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace 图形界面WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string DeskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//桌面的位置
                        
        }

   


        /// <summary>
        /// 点击之后建立一个项目的文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MenuItemNewProject_OnClick(object sender, RoutedEventArgs e)
        {
            //路径选择

        }

        void MenuItemOpenProject_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
