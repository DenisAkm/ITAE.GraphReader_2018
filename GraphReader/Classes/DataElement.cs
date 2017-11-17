using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphReader.Classes
{
    public class DataElement
    {
        public float[,] Values;
        public string Title;        
        public int Rows;
        public float[] Median;
        public float[] Middle;
        public float Max;
        public float Min;
        bool Reverse;
        static public float GlobalBegin;
        static public float GlobalEnd;
        public float Begin;
        public float End;
        public bool Break;
        public float Start, Step, Finish;        
        public int Sectors;
        public float MedianMax;
        public float MedianMin;
        public float MiddleMax;
        public float MiddleMin;
        public DataElement(string title, int nrows)
        {
            Title = title;
            
            Rows = nrows;
            Values = new float[nrows, 2];            
        }

        public DataElement(StringTable table, int getColumn)
        {
            Title = "Get from table";
            Rows = table.RowsCount;
            Values = new float[Rows, 2];
            for (int i = 0; i < Rows; i++)
            {
                Values[i, 0] = Convert.ToSingle(table.Cell[0, i].Replace('\0', '.').Replace(".", ","));
                Values[i, 1] = Convert.ToSingle(table.Cell[getColumn, i].Replace('\0', '.').Replace(".", ","));
            }
            FindMinMax();
        }
        public void Compile(float start, float finish, float step)
        {
            Sectors = Convert.ToInt32(Math.Ceiling((finish - start) / step));
            Median = new float[Sectors];
            Middle = new float[Sectors];
            Start = start;
            Finish = finish;
            Step = step;
            

            if (Prove())
            {
                Break = false;
                ArithmeticMean();
                if (!Break)
                {
                    Medianvalue();    
                }
                if (!Break)
                {
                    FindMinMaxCalculated();    
                }                
            }
            else
            {
                Break = true;
            }
        }
        public void FindMinMax()
        {
            Min = Values[0, 1];
            Max = Values[0, 1];
            for (int i = 1; i < Rows; i++)
            {
                float val = Values[i, 1];
                if (val < Min)
                {
                    Min = val;
                }
                if (val > Max)
                {
                    Max = val;
                }
            }

            if (Values[0, 0] < Values[Rows - 1, 0])
            {
                Reverse = false;
                Begin = Values[0, 0];
                End = Values[Rows - 1, 0];
            }
            else
            {
                Reverse = true;
                End = Values[0, 0];
                Begin = Values[Rows - 1, 0];
            }
            if (Begin < GlobalBegin)
            {
                GlobalBegin = Begin;
            }
            if (End > GlobalEnd)
            {
                GlobalEnd = End;
            }
        }
        private bool Prove()
        {
            bool answer = true;
            
           

            String mess = "Установленный диапазон рассчета выходит за границы считанных данных. Поменяйте границы или проверьте формат данных файла.";
            if (Values[0, 0] < Values[Rows - 1, 0])
            {
                if (Values[0, 0] > Start || Values[Rows - 1, 0] < Finish)
                {
                    MessageBox.Show(mess, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    answer = false;
                }
            }
            if (Values[0, 0] > Values[Rows - 1, 0])
            {
                if (Values[0, 0] < Finish || Values[Rows - 1, 0] > Start)
                {
                    MessageBox.Show(mess, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    answer = false;
                }
            }
            if (Values[0, 0] == Values[Rows - 1, 0])
            {
                MessageBox.Show(mess, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                answer = false;
            }


            for (int i = 1; i < Rows; i++)
            {
                if (Values[i, 0] >= Start && Values[i, 0] <= Finish)
                {
                    //
                    // Проверка на разрывы
                    //                    
                    if (Reverse)
                    {
                        if (Values[i - 1, 0] < Values[i, 0])
                        {
                            String mes = String.Concat("Обнаружен разрыв в строчке ", i, ". Значения в колонке X должный быть монотонными.");
                            MessageBox.Show(mes, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            answer = false;
                        }
                    }
                    else
                    {
                        if (Values[i - 1, 0] > Values[i, 0])
                        {
                            String mes = String.Concat("Обнаружен разрыв в строчке ", i, ". Значения в колонке X должный быть монотонными.");
                            MessageBox.Show(mes, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            answer = false;
                        }
                    }
                }
            }
            return answer;
        }

        private void ArithmeticMean()
        {
            int k = 1;
            float sum = 0;
            int count = 0;
            if (Reverse)
            {
                for (int i = Rows - 1; i >= 0; i--)
                {
                    if (Values[i, 0] <= Finish && Values[i, 0] >= Start)
                    {
                        while (Values[i, 0] >= Start && Values[i, 0] <= Start + Step * k)
                        {                            
                            sum += Values[i, 1];
                            count++;
                            if (Values[i, 0] >= Finish)
                            {
                                break;
                            }
                            i--;
                            
                        }
                        if (count == 0)
                        {
                            MessageBox.Show("В один из секторов не попало ни одного значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Break = true;
                            goto End;
                        }
                        Middle[k - 1] = sum / count;
                        sum = 0;
                        count = 0;
                        k++;
                    }
                }            
            }
            else
            {
                for (int i = 0; i < Rows; i++)
                {
                    if (Values[i, 0] >= Start && Values[i, 0] <= Finish)
                    {
                        while (Values[i, 0] >= Start && (Values[i, 0] <= Start + Step * k))
                        {                               
                            sum += Values[i, 1];
                            count++;
                            if (Values[i, 0] >= Finish)
                            {
                                break;
                            }
                            i++;
                            
                        }
                        if (count == 0)
                        {
                            MessageBox.Show("В один из секторов не попало ни одного значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Break = true;
                            goto End;
                        }
                        Middle[k - 1] = sum / count;
                        sum = 0;
                        count = 0;
                        k++;
                    }
                }
            }
        End: ;
        }
        private void Medianvalue()
        {
            List<Single> buff = new List<float>();            

            int k = 1;

            if (Reverse)
            {
                for (int i = Rows - 1; i >= 0; i--)
                {
                    if (Values[i, 0] >= Start && Values[i, 0] <= Finish)
                    {
                        while (Values[i, 0] >= Start && Values[i, 0] <= Start + Step * k)
                        {
                            
                            buff.Add(Values[i, 1]);
                            if (Values[i, 0] >= Finish)
                            {
                                break;
                            }
                            i--;
                        }                        
                        buff.Sort();
                        int members = buff.Count;
                        if (members == 0)
                        {
                            MessageBox.Show("В один из секторов не попало ни одного значения","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Break = true;
                            goto End;
                        }
                        if (members % 2 == 0)
                        {
                            Median[Sectors - k] = (buff[members / 2 - 1] + buff[members / 2]) / 2;
                        }
                        else
                        {
                            Median[Sectors - k] = buff[(members - 1) / 2];
                        }
                        buff.Clear();
                        k++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < Rows; i++)
                {
                    if (Values[i, 0] >= Start && Values[i, 0] <= Finish)
                    {
                        while (Values[i, 0] >= Start && Values[i, 0] <= Start + Step * k)
                        {                            
                            buff.Add(Values[i, 1]);                            
                            if (Values[i, 0] >= Finish)
                            {
                                break;
                            }
                            i++;
                        }
                        buff.Sort();
                        int members = buff.Count;
                        if (members == 0)
                        {
                            MessageBox.Show("В один из секторов не попало ни одного значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Break = true;
                            goto End;
                        }
                        if (members % 2 == 0)
                        {
                            Median[k - 1] = (buff[members / 2 - 1] + buff[members / 2]) / 2;
                        }
                        else
                        {
                            Median[k - 1] = buff[(members - 1) / 2];
                        }
                        buff.Clear();
                        k++;
                    }
                }
            }
            End: ;
        }

        private void FindMinMaxCalculated()
        {
            MiddleMin = Middle[0];
            MiddleMax = Middle[0];
            for (int i = 0; i < Middle.Length; i++)
            {
                float val = Middle[i];
                if (val > MiddleMax)
                {
                    MiddleMax = val;
                }
                if (val < MiddleMin)
                {
                    MiddleMin = val;
                }
            }

            MedianMin = Median[0];
            MedianMax = Median[0];
            for (int i = 0; i < Median.Length; i++)
            {
                float val = Median[i];
                if (val > MedianMax)
                {
                    MedianMax = val;
                }
                if (val < MedianMin)
                {
                    MedianMin = val;
                }
            }
        }
        
    }
}
