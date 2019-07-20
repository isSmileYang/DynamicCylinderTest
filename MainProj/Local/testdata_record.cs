using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace MainProj.Local
{
    public class testdata_record
    {
        #region Property
        public int DataCount { get; set; }
        public DataTable table { get; set; }//临时数据表
        public byte[] dataBLOB { get; set; }//二进制文件
        #endregion

        #region Fileds
        public Thread threadTestRecord;
        public System.Timers.Timer testTimer = new System.Timers.Timer();
        //log4net.ILog log = log4net.LogManager.GetLogger(typeof(Valve));
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//获取调用方法的类(class)的类型(type)。
        string[] datas = new string[]{"asd"};
        Dictionary<string, string> NameAndType;
        #endregion

        #region Indexer
        
        #endregion
        public testdata_record()
        {
            NameAndType = new Dictionary<string, string>() { //要保存的内容及其格式
            {"序号",          "System.Int32"},
            {"测试时间",      "System.String"},
            {"油源压力",      "System.Double"},
            {"油源流量",      "System.Double"},
            //{"油源实际压力",  "System.Double"},
            //{"油源实际流量",  "System.Double"},
            {"流量计LL31流量","System.Double"},
            {"流量计LL32流量","System.Double"},
            {"流量计LL33流量","System.Double"},
            {"阀13位移缓存",      "System.Double"},
            {"P口压力",       "System.Double"},
            {"T口压力",       "System.Double"},
            {"A口压力",       "System.Double"},
            {"B口压力",       "System.Double"},
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
            testTimer.Interval = 500;
            testTimer.Enabled = true;
            testTimer.Start();
            testTimer.Elapsed += new ElapsedEventHandler(timer_Tick);//事件绑定
        }

        public void EndRecort()//timer结束计时，保存数据
        {
            testTimer.Stop();
            DataTableToExcel(table);
        }

        void timer_Tick(object sender, ElapsedEventArgs e)//记录数据并添加到table
        {
            DataRow row = table.NewRow();
            int i=0;
            foreach(KeyValuePair<string, string> kvp in NameAndType)
            {
                if (i == 0) { row[i++] = ++this.DataCount; }
                else if (i == 1) { row[i++] = System.DateTime.Now; }
                else{
                    //row[i++]=Group[kvp.Key];  改成从Ethercat添加数据
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
    }
        #endregion
}
