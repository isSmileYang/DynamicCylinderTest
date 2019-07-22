using HyTestRTDataService.RunningMode;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProj.Local
{
    class TestRecorder
    {
        #region Property
        public int DataCount { get; set; }
        public DataTable table { get; set; }//临时数据表
        public byte[] dataBLOB { get; set; }//二进制文件
        private int recordSpeed;
        #endregion

        #region Fileds
        private RunningServer server = RunningServer.getServer();
        private Timer testTimer = new Timer();
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(MainForm));
        Dictionary<string, string> NameAndType;
        #endregion

        #region Indexer

        #endregion

        public TestRecorder(int recordSpeed)
        {
            this.recordSpeed = recordSpeed;
            testTimer.Interval = recordSpeed;
            NameAndType = new Dictionary<string, string>() { //要保存的内容及其格式
            {"序号",             "System.Int32"},
            {"测试时间",         "System.String"},
            {"油源压力",         "System.Double"},
            {"油源流量",         "System.Double"},
            {"流量计LL31流量",   "System.Double"},
             {"内缸压力传感器值", "System.Double"},
            {"位移传感器LVDT",   "System.Double"},
            {"A口压力",         "System.Double"},
            {"B口压力",         "System.Double"},
            };
            table = new DataTable();
            GetDataTable();
        }
        #region Methods
        /// <summary>
        /// 新建空DataTable,并新建进程开始记录数据
        /// </summary>
        /// <returns></returns>
        public void GetDataTable()
        {
            foreach (KeyValuePair<string, string> kvp in NameAndType)
            {
                table.Columns.Add(kvp.Key, Type.GetType(kvp.Value));
            }
            this.DataCount = 0;
        }

        public void StartRecord()//timer开始计时，每0.5s记录一组数据
        {
            testTimer.Enabled = true;
            testTimer.Tick += timer_Tick;//事件绑定
            //testTimer.Start();
        }

        public void EndRecort()//timer结束计时，保存数据
        {
            testTimer.Stop();
            //DataTableToExcel(table);---test
        }

        void timer_Tick(object sender, EventArgs e)//记录数据并添加到table
        {
            DataRow row = table.NewRow();
            int i = 0;
            foreach (KeyValuePair<string, string> kvp in NameAndType)
            {
                if (i == 0) { row[i++] = ++this.DataCount; }
                else if (i == 1) { row[i++] = System.DateTime.Now; }
                else
                {
                   // row[i++] = server.NormalRead<double>(kvp.Key);//只记录double类型？
                }
            }
            table.Rows.Add(row);
        }

        /// <summary>
        /// Datatable生成Excel表格，并将Excel生成二进制文件存入dataBLOB
        /// </summary>
        /// <param name="m_DataTable">Datatable</param>
        /// <returns></returns>
        public void DataTableToExcel(System.Data.DataTable m_DataTable)
        {
            string FileName = Path.GetFullPath("..") + "\\report\\" + System.DateTime.Now.ToString("yyyy-mm-dd") + "实验数据.xls";//文件路径在report目录下
            if (System.IO.File.Exists(FileName))                                //存在则删除
            {
                log.Info("文件已存在，将被覆盖");
                System.IO.File.Delete(FileName);
            }
            System.IO.FileStream objFileStream;
            System.IO.StreamWriter objStreamWriter;
            string strLine = "";
            objFileStream = new System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            objStreamWriter = new System.IO.StreamWriter(objFileStream, Encoding.Unicode);
            for (int i = 0; i < m_DataTable.Columns.Count; i++)
            {
                strLine = strLine + m_DataTable.Columns[i].Caption.ToString() + Convert.ToChar(9);      //写列标题
            }
            objStreamWriter.WriteLine(strLine);
            strLine = "";
            for (int i = 0; i < m_DataTable.Rows.Count; i++)
            {
                for (int j = 0; j < m_DataTable.Columns.Count; j++)
                {
                    try
                    {
                        if (m_DataTable.Rows[i].ItemArray[j] == null)
                            strLine = strLine + " " + Convert.ToChar(9);                                    //写内容
                        else
                        {
                            string rowstr = "";
                            rowstr = m_DataTable.Rows[i].ItemArray[j].ToString();
                            if (rowstr.IndexOf("\r\n") > 0)
                                rowstr = rowstr.Replace("\r\n", " ");
                            if (rowstr.IndexOf("\t") > 0)
                                rowstr = rowstr.Replace("\t", " ");
                            strLine = strLine + rowstr + Convert.ToChar(9);
                        }
                    }
                    catch (IndexOutOfRangeException e)//防止超出范围
                    {
                        log.Error("实验数据记录异常" + e);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";
            }
            /**关闭其他流文件**/
            objStreamWriter.Close();
            objFileStream.Close();
            /**转Excel为二进制文件**/
            FileStream getBinExcel = new FileStream(FileName, FileMode.Open);
            dataBLOB = new byte[getBinExcel.Length];
            getBinExcel.Read(dataBLOB, 0, (int)getBinExcel.Length);
            getBinExcel.Close();
        }
        #endregion
    }
}
