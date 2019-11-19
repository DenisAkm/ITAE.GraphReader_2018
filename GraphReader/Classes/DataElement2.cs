using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphReader.Classes
{
    public class DataElement2
    {
        string[,] table;
        public string Name { get; set; }
        public int ColumnsCount
        {
            get
            {
                return table.GetLength(0);
            }
        }
        public int RowsCount
        {
            get
            {
                return table.GetLength(1);
            }
        }

        public bool Changed { get; set; }

        public string this[int col, int row]
        {
            get 
            {
                return table[col, row];
            }
            set 
            {
                table[col, row] = value;
            }
        }

        public DataElement2(string name, string[,] cells)
        {
            table = cells;
            Name = name;
        }
        public double[] ReturnColumn(int c)
        {
            int rowsCount = RowsCount;
            double[] v = new double[rowsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                v[i] = Convert.ToDouble(this[c,i].Replace('\0', '.').Replace(".", ","));    
            }            
            
            return v;
        }

        public string[,] Table
        {
            set 
            {
                table = value;
            }
        }

        public double Min
        {
            get
            {
                double min = Convert.ToDouble(table[0, 1]);

                for (int i = 1; i < RowsCount; i++)
                {
                    double val = Convert.ToDouble(table[i, 1]);
                    if (val < min)
                    {
                        min = val;
                    }                    
                }                
                return min;
            }
        }

        public double Max
        { 
            get
            {
                double max = Convert.ToDouble(table[0, 1]);
                for (int i = 1; i < RowsCount; i++)
                {
                    double val = Convert.ToDouble(table[i, 1]);
                    if (val > max)
                    {
                        max = val;
                    }
                }
                return max;
            }
        
        }
    }
}
