using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace GraphReader.Classes
{
    public class Curve
    {
        public static List<Curve> CurveList = new List<Curve>();
        public double[] X;
        public double[] Y;
        public string Title { get; set; }
        /// <summary>
        /// Количество точек оригинальной кривой
        /// </summary>
        public int Count
        {
            get
            {
                return X.Length;
            }
        }
        public string Code;
        public ListViewItem ListItem;
        TreeNode Node;
        public LineItem LineOnGraph;
        public bool CheckedTodB;
        public bool CheckedToTimes;
        public bool CheckedToNorma;
        public RadioButton currentModifier;

        public Curve(TreeNode _node)
        {

            Title = _node.Text;
            Node = _node;
            Code = Curve.GetUniqCode();

            DataElement2 de = MainForm.Instance.LoadedData.Find(x => x.Name == _node.Parent.Tag.ToString());
            int columnY = _node.Index;
            X = de.ReturnColumn(0);
            Y = de.ReturnColumn(columnY + 1);

            string AB = (_node.Text.Split(' '))[1];
            string parentNodeTitle = _node.Parent.Text;

            MainForm.Instance.listViewGraphBrowserItemChecked_trigger = false;
            ListItem = new ListViewItem(String.Concat(parentNodeTitle, "_", AB));
            ListItem.Checked = true;
            MainForm.Instance.listViewGraphBrowser.Items.Add(ListItem);
            MainForm.Instance.listViewGraphBrowser.Width = -1;
            MainForm.Instance.listViewGraphBrowserItemChecked_trigger = true;


            CurveList.Add(this);
        }

        public void HideGraph()
        {
            MainForm.Instance.GraphRemoveCurve(this);
            LineOnGraph = null;
        }
        public void ShowGraph(RadioButton modifier, bool _checkedTodB, bool _checkedToTimes, bool _checkedToNorma)
        {
            if (modifier.Text == "Оригинальное")
            {
                LineOnGraph = MainForm.Instance.GraphAddCurve(this.Code, X, Y);
            }
            if (modifier.Text == "Медианное")
            {
                var t = Medianvalue(SettingsForm.Start, SettingsForm.Finish, SettingsForm.Step);
                LineOnGraph = MainForm.Instance.GraphAddCurve(this.Code, t.Item1, t.Item2);
            }
            if (modifier.Text == "Среднеарифметическое")
            {
                var t = Middlevalue(SettingsForm.Start, SettingsForm.Finish, SettingsForm.Step);
                LineOnGraph = MainForm.Instance.GraphAddCurve(this.Code, t.Item1, t.Item2);
            }
            if (_checkedTodB)
            {
                if (OnlyPositive(LineOnGraph.Points))
                {
                    for (int j = 0; j < LineOnGraph.Points.Count; j++)
                    {
                        LineOnGraph.Points[j].Y = 20 * Math.Log10(LineOnGraph.Points[j].Y);
                    }
                }
                else
                {
                    MainForm.Instance.breaking = true;
                    MainForm.Instance.checkBox_dB.Checked = false;
                    MainForm.Instance.breaking = false;
                    MessageBox.Show("Не все графики могуть быть нарисованы в логирифмической шкале.");
                }                   
            }
            if (_checkedToTimes)
            {
                for (int j = 0; j < LineOnGraph.Points.Count; j++)
                {
                    LineOnGraph.Points[j].Y = Math.Pow(10, LineOnGraph.Points[j].Y / 20);
                }
            }
            if (_checkedToNorma)
            {
                double max = GetMax;
                for (int j = 0; j < LineOnGraph.Points.Count; j++)
                {
                    LineOnGraph.Points[j].Y = LineOnGraph.Points[j].Y - max;
                }
            }
            currentModifier = modifier;
            CheckedTodB = _checkedTodB;
            CheckedToTimes = _checkedToTimes;
            CheckedToNorma = _checkedToNorma;            
        }

        private bool OnlyPositive(IPointList pointList)
        {
            bool answer = true;
            for (int i = 0; i < pointList.Count; i++)
            {
                if (pointList[i].Y < 0)
                {
                    answer = false;
                }
            }
            return answer;
        }

        public static string GetUniqCode()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, 50).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void Delete(Curve c)
        {
            CurveList.Remove(c);
            if (c.LineOnGraph != null)
            {
                c.HideGraph();
            }
            MainForm.Instance.listViewGraphBrowser.Items.Remove(c.ListItem);
        }

        private Tuple<double[], double[]> Medianvalue(double Start, double Finish, double Step)
        {
            List<double> buff = new List<double>();
            bool Reverse = false;
            int Rows = Count;
            int Sectors = Convert.ToInt32(Math.Ceiling((Finish - Start) / Step));

            double[] MedianY = new double[Sectors];


            if (X[0] > X[X.Length - 1])
            {
                Reverse = true;
            }

            int k = 1;

            if (Reverse)
            {
                for (int i = Rows - 1; i >= 0; i--)
                {
                    if (X[i] >= Start && X[i] <= Finish)
                    {
                        while (X[i] >= Start && X[i] <= Start + Step * k)
                        {
                            buff.Add(Y[i]);
                            if (X[i] >= X[X.Length - 1])
                            {
                                break;
                            }
                            i--;
                        }
                        buff.Sort();
                        int members = buff.Count;

                        if (members == 0)
                        {
                            MessageBox.Show("В один из секторов не попало ни одного значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (members % 2 == 0)
                        {
                            MedianY[Sectors - k] = (buff[members / 2 - 1] + buff[members / 2]) / 2;
                        }
                        else
                        {
                            MedianY[Sectors - k] = buff[(members - 1) / 2];
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
                    if (X[i] >= Start && X[i] <= Finish)
                    {
                        while (X[i] >= Start && X[i] <= Start + Step * k)
                        {
                            buff.Add(Y[i]);
                            if (X[i] >= X[X.Length - 1])
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
                            break;
                        }
                        if (members % 2 == 0)
                        {
                            MedianY[k - 1] = (buff[members / 2 - 1] + buff[members / 2]) / 2;
                        }
                        else
                        {
                            MedianY[k - 1] = buff[(members - 1) / 2];
                        }
                        buff.Clear();
                        k++;
                    }
                }
            }

            double[] x = new double[2 * Sectors];
            double[] y = new double[2 * Sectors];

            for (int i = 0; i < Sectors; i++)
            {
                x[2 * i] = Start + Step * i;
                if (i == 0 && Start < X[0])
                {
                    x[0] = X[0];                    
                }
                y[2 * i] = MedianY[i];
                x[2 * i + 1] = Start + Step * (i + 1);                
                if (Start + Step * (i + 1) > Finish)
                {                    
                    x[2 * i + 1] = Finish;                    
                }
                if (i == Sectors - 1 && Finish > X[X.Length - 1])
                {
                    x[2 * i + 1] = X[X.Length - 1];
                }

                y[2 * i + 1] = MedianY[i];
            }
            return Tuple.Create<double[], double[]>(x, y);
        }

        private Tuple<double[], double[]> Middlevalue(double Start, double Finish, double Step)
        {                                    
            int Rows = Count;
            int Sectors = Convert.ToInt32(Math.Ceiling((Finish - Start) / Step));

            double[] MiddleY = new double[Sectors];

            bool Reverse = false;
            if (X[0] > X[X.Length - 1])
            {
                Reverse = true;
            }

            int k = 1;
            double sum = 0;
            int count = 0;
            if (Reverse)
            {
                for (int i = Rows - 1; i >= 0; i--)
                {
                    if (X[i] <= Finish && X[i] >= Start)
                    {
                        while (X[i] >= Start && X[i] <= Start + Step * k)
                        {
                            sum += Y[i];
                            count++;
                            if (X[i] >= X[X.Length - 1])
                            {
                                break;
                            }
                            i--;

                        }
                        if (count == 0)
                        {
                            break;                            
                        }
                        MiddleY[k - 1] = sum / count;
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
                    if (X[i] >= Start && X[i] <= Finish)
                    {
                        while (X[i] >= Start && (X[i] <= Start + Step * k))
                        {
                            sum += Y[i];
                            count++;
                            if (X[i] >= X[X.Length - 1])
                            {
                                break;
                            }
                            i++;

                        }
                        if (count == 0)
                        {
                            MessageBox.Show("В один из секторов не попало ни одного значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        MiddleY[k - 1] = sum / count;
                        sum = 0;
                        count = 0;
                        k++;
                    }
                }
            }
            double[] x = new double[2 * Sectors];
            double[] y = new double[2 * Sectors];

            for (int i = 0; i < Sectors; i++)
            {
                x[2 * i] = Start + Step * i;
                if (i == 0 && Start < X[0])
                {
                    x[0] = X[0];
                }
                y[2 * i] = MiddleY[i];
                x[2 * i + 1] = Start + Step * (i + 1);
                if (Start + Step * (i + 1) > Finish)
                {
                    x[2 * i + 1] = Finish;
                }
                if (i == Sectors - 1 && Finish > X[X.Length - 1])
                {
                    x[2 * i + 1] = X[X.Length - 1];
                }

                y[2 * i + 1] = MiddleY[i];
            }
            return Tuple.Create<double[], double[]>(x, y);
        }

        public static void Clear()
        {
            int count = CurveList.Count;
            for (int i = 0; i < count; i++)
            {
                Delete(CurveList[0]);
            }
        }



        public double GetMax
        {
            get
            {
                double max = LineOnGraph.Points[0].Y;
                for (int i = 1; i < LineOnGraph.Points.Count; i++)
                {
                    if (max < LineOnGraph.Points[i].Y)
                    {
                        max = LineOnGraph.Points[i].Y;
                    }   
                }
                return max;
            }
        }
    }
}
