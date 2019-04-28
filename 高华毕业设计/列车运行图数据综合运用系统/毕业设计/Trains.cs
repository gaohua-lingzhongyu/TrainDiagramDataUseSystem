using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 毕业设计
{

    //代表的是运行图里面的一个列车
   public class Trains
    {
        public List<TrainLine> sections;
        public bool beSelected;//用来记录绘图时车是否被选中，在绘图结束后仍然为false
        public string trainId;
        public PointF startPo;//列车运行线的起始点
        public PointF endPo;//列车运行线的终止点

        public Trains(List<TrainLine> sections, string trainId, PointF startPo, PointF endPo)
        {
            this.sections = sections;
            this.trainId = trainId;
            this.startPo = startPo;
            this.endPo = endPo;
            this.beSelected = false;
        }

    }
}
