using System;
using System.IO;
using System.Windows.Forms;

namespace 毕业设计
{
    public partial class NewProject : Form
    {
        public NewProject()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//窗体居中
            this.ProjectNametextBox.Text = "新建项目";
            string strDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//获取桌面路径
            this.LocationOfProjectTextBox.Text = strDesktopPath;//默认的新建项目路径为桌面路径
        }

        /// <summary>
        /// 路径旁边的浏览按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowserButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                SelectedPath = this.LocationOfProjectTextBox.Text
            }; //选择项目的新建项目路径
            //路径浏览器的初始定位
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                //如果返回值为确定的话
                this.LocationOfProjectTextBox.Text = folderBrowserDialog.SelectedPath;//路径文本框为选定的路径
            }
        }

        /// <summary>
        /// 确定新建项目名称及路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKBtn_Click(object sender, EventArgs e)
        {
            //如果点击确定的话，新建文件夹
            var newProjectFolder = Path.Combine(this.LocationOfProjectTextBox.Text, this.ProjectNametextBox.Text);//创建一个新的地址
            if (Directory.Exists(newProjectFolder))
            {
                MessageBox.Show($"项目   {newProjectFolder}   已存在请更换项目名称", "提示");
            }
            else
            {
                Directory.CreateDirectory(newProjectFolder);//创建当前文件夹
            }
        }

        /// <summary>
        /// 取消按钮，关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}