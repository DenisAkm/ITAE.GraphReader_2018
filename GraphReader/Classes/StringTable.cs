using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphReader.Classes
{
    public class StringTable
    {
        public string[,] Cell;
        public int ColomnsCount;
        public int RowsCount;
        public string Name;
        public bool Changed;
        public StringTable(string name, int cols, int rows)
        {
            ColomnsCount = cols;
            RowsCount = rows;
            Cell = new string[cols, rows];
            Name = name;
            Changed = false;
        }
        public StringTable()
        {
            ColomnsCount = 0;
            RowsCount = 0;
            Changed = false;
        }
    }
}
