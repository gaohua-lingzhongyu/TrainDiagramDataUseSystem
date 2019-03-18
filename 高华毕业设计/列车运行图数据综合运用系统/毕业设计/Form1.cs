using System;
using System.Drawing;
using System.Windows.Forms;

namespace 毕业设计
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                control.Font = new Font("微软雅黑", 12);
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Location = new Point(panelofPic.Location.X + panelofPic.Size.Width, panelofPic.Location.Y + panelofPic.Size.Height);//panel的占位符，为了出现滚动条
            this.label1.Text = @"占位符";
            //注意还要修改
        }

        private int _flag;//当前确定的分钟格数显示值，2，5，10

        private void 生成底图结构ToolStripMenuItem_Click_1(object sender, EventArgs e)//10分格的底图结构生成
        {
            //生成10分格底图结构
            this.panelofPic.SetAutoScrollMargin(400, 100);//使用scrollbar来控制显示图像的范围
            TrainBasicPicture trainBasicPicture10 = new TrainBasicPicture
            {
                Width = this.panelofPic.Size.Width,
                Height = this.panelofPic.Size.Height,
                TrainBasicPicturePos =
                    new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 10)
            }; //声明10分格底图结构实例
            //底图结构的宽度
            //底图结构的高度
            pictureBox1.BackgroundImage = trainBasicPicture10.DrawTrainBasicPicture(TrainBasicPicture.Scale.TenMinutes);//将返回的bitmap设置为picbox的背景图片
            _flag = 10;//当前的flag为10分格数
        }

        private void panelofPic_Paint(object sender, PaintEventArgs e)
        {
        }

        private void 生成5分格底图结构ToolStripMenuItem_Click(object sender, EventArgs e)//5分格底图结构的生成
        {
            //生成5分格的底图结构
            this.panelofPic.SetAutoScrollMargin(3000, 100);//使用scrollbar来控制显示图像的范围
            TrainBasicPicture trainBasicPicture5 = new TrainBasicPicture
            {
                Width = this.panelofPic.Width * 2,
                Height = this.panelofPic.Height,
                TrainBasicPicturePos =
                    new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 10)
            }; //声明5分格底图结构实例
            pictureBox1.BackgroundImage = trainBasicPicture5.DrawTrainBasicPicture(TrainBasicPicture.Scale.FiveMinutes);//将返回的bitmap设置为picbox的背景图片
            _flag = 5;//当前的flag为10分格数
        }

        private void 生成2分格底图结构ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //生成2分格的底图结构
            this.panelofPic.SetAutoScrollMargin(100000, 100);//使用scrollbar来控制显示图像的范围
            TrainBasicPicture trainBasicPicture2 = new TrainBasicPicture
            {
                Width = this.panelofPic.Width * 5,
                Height = this.panelofPic.Height,
                TrainBasicPicturePos =
                    new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 10)
            }; //声明5分格底图结构实例
            pictureBox1.BackgroundImage = trainBasicPicture2.DrawTrainBasicPicture(TrainBasicPicture.Scale.TwoMinutes);//将返回的bitmap设置为picbox的背景图片
            _flag = 2;//当前的flag为10分格数
        }

        private void panelofPic_Scroll(object sender, ScrollEventArgs e)//拖动滑动条时进行重绘
        {
            //生成5分格的底图结构
            if (_flag == 10)
            {
            }
            else if (_flag == 5)
            {
                this.panelofPic.SetAutoScrollMargin(this.panelofPic.Width * 2, 100);
                TrainBasicPicture trainBasicPicture5 = new TrainBasicPicture
                {
                    Width = this.panelofPic.Width * 2,
                    Height = this.panelofPic.Height,
                    TrainBasicPicturePos =
                        new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 10)
                }; //声明5分格底图结构实例
                pictureBox1.BackgroundImage =
                    trainBasicPicture5.DrawTrainBasicPicture(TrainBasicPicture.Scale
                        .FiveMinutes); //将返回的bitmap设置为pictbox的背景图片
                _flag = 5; //当前的flag为10分格数
            }
            else if (_flag == 2)
            {
                //生成2分格的底图结构
                this.panelofPic.SetAutoScrollMargin(this.panelofPic.Width * 5, 100); //使用scrollbar来控制显示图像的范围
                TrainBasicPicture trainBasicPicture2 = new TrainBasicPicture
                {
                    Width = this.panelofPic.Width * 5,
                    Height = this.panelofPic.Height,
                    TrainBasicPicturePos =
                        new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 10)
                }; //声明5分格底图结构实例
                pictureBox1.BackgroundImage =
                    trainBasicPicture2.DrawTrainBasicPicture(TrainBasicPicture.Scale
                        .TwoMinutes); //将返回的bitmap设置为picbox的背景图片
                _flag = 2; //当前的flag为10分格数
            }
        }
    }
}