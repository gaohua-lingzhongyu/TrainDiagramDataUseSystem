using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace 毕业设计
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                control.Font = new Font("微软雅黑", 12);
            }
        }

        private void 运行图绘制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 trainPictureFrom = new Form1 { TopLevel = false, Parent = this };
            //非常重要的一个步骤
            //设置绘图界面的窗口父窗口为当前窗口
            trainPictureFrom.Show();
        }

        private void 新建项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //点击新建项目
            NewProject newProjectFrom = new NewProject();
            newProjectFrom.ShowDialog();
        }

        private void 打开已有项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            };
            //获取桌面路径
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            Directory.SetCurrentDirectory(folderBrowserDialog.SelectedPath);//设置当前的工作目录
            MessageBox.Show($@"当前的工作目录为   {folderBrowserDialog.SelectedPath}");
        }

        private void 车次运营状态查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_trainTimeData trainIdForm = new Form_trainTimeData()
            { TopLevel = false, Parent = this };
            trainIdForm.Show();
        }

        private void 具体车次时刻表生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_trainTimeTable formTrainTimeTable = new Form_trainTimeTable() { TopLevel = false, Parent = this };
            formTrainTimeTable.Show();
        }

        private void 网站数据抓取ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process pro_get12306Data = new Process {StartInfo = {FileName = @".\数据爬取部分\Debug\沪宁高铁数据.exe"}};
            pro_get12306Data.Start();
            pro_get12306Data.WaitForExit();
            pro_get12306Data.Dispose();
        }
    }
}