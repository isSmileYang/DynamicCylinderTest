using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProj.Utils
{
    public class TableGener
    {
        private IList<Table> tableList = new List<Table>();
        public TableGener()
        { }

        public void AddTable(Table table)
        {
            this.tableList.Add(table);
        }
        public  void tableGener(Dictionary<string,List<double[]>> tableDict)
        {
        
        
              foreach( Table table in tableList)
              {
                  
              }
        }

    }
}

