using System.Drawing;

namespace 毕业设计
{
    //对图纸进行相关的编辑操作
    internal class Edit
    {
        /// <summary>
        /// 画线编辑
        /// </summary>
        /// <param name="line">线实例</param>
        /// <param name="graphics">图实例</param>
        public static void DrawLine(Line line, Graphics graphics)
        {
            Pen pen = new Pen(line.Color, line.Width);//定义画笔颜色
            graphics.DrawLine(pen, line.StartPoint, line.EndPoint);//画布上面画线
        }
    }
}