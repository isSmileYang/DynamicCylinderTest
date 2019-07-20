using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace MainProj.Util 
{
    public class GraphInfo
    {
        private string xtitle, ytitle,y2title, title;
        private int xMax, xMin, yMax, yMin;
        private PointPairList list, list2;
        public string imageSavePath;

        #region properties
        public string Title
        {
            get
            {
                return this.title;
            }
        }
        public string XTitle
        {
            get
            {
                return this.xtitle;
            }
        }
        public string YTitle
        {
            get
            {
                return this.ytitle;
            }
        }
        public string Y2Title
        {
            get
            {
                return this.y2title;
            }
            set
            {
                this.y2title = value;
            }
        }
        public int XMax
        {
            get
            {
                return this.xMax;
            }
        }
        public int XMin
        {
            get
            {
                return this.xMin;
            }
        }
        public int YMax
        {
            get
            {
                return this.yMax;
            }
        }
        public int YMin
        {
            get
            {
                return this.yMin;
            }
        }
        public PointPairList List
        {
            get
            {
                return this.list;
            }
            set
            {
                this.list = value;
            }
        }
        public PointPairList List2
        {
            get
            {
                return this.list2;
            }
            set
            {
                this.list2 = value;
            }
        }
        public bool hasY2 { get; set; }
        #endregion

        public GraphInfo(string title, string xtitle, string ytitle, string path)
        {
            this.title = title;
            this.xtitle = xtitle;
            this.ytitle = ytitle;
            this.list = new PointPairList();
            this.imageSavePath = path;
            this.hasY2 = false;
        }
        
        /// <summary>
        /// 重构，用于带有次坐标轴的生成
        /// </summary>
        public GraphInfo(string title, string xtitle, string ytitle, string ytitle2, string path)
        {
            this.title = title;
            this.xtitle = xtitle;
            this.ytitle = ytitle;
            this.y2title = ytitle2;
            this.list = new PointPairList();
            this.list2 = new PointPairList();
            this.imageSavePath = path;
            this.hasY2 = true;
        }
    }
}
