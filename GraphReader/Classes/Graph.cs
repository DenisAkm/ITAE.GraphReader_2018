using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace MDX11Form.Classes
{
    partial class Graph : ZedGraphControl
    {
        private System.ComponentModel.IContainer components = null;

        LineItem curvePhi;
        LineItem curveTheta;
        LineItem curveTotal;
        LineItem curvePhiAntenna;
        LineItem curveThetaAntenna;
        LineItem curveTotalAntenna;
        LineItem curvePhiReflaction;
        LineItem curveThetaReflaction;
        LineItem curveTotalReflaction;
        LineItem curvePhiReflactionTrans;
        LineItem curveThetaReflactionTrans;
        LineItem curveTotalReflactionTrans;
        LineItem curvePhiTotal;
        LineItem curveThetaTotal;
        LineItem curveTotalTotal;
        LineItem memoryCurve1;

        Color ColorPhi = Color.DarkBlue;
        Color ColorTheta = Color.Teal;
        Color ColorTotal = Color.FromArgb(0, 162, 232);
        Color ColorPhiA = Color.DarkRed;
        Color ColorThetaA = Color.DarkGoldenrod;
        Color ColorTotalA = Color.Red;
        Color ColorPhiR = Color.Aqua;
        Color ColorThetaR = Color.Chocolate;
        Color ColorTotalR = Color.SpringGreen;
        Color ColorPhiRT = Color.DarkTurquoise;
        Color ColorThetaRT = Color.LightPink;
        Color ColorTotalRT = Color.SandyBrown;

        Color ColorPhiT = Color.Azure;
        Color ColorThetaT = Color.Crimson;
        Color ColorTotalT = Color.Maroon;
        Color ColorM1 = Color.Black;

        public GraphPane myPane = new GraphPane();
        public PointPairList ListPhi = new PointPairList();
        public PointPairList ListTheta = new PointPairList();
        public PointPairList ListTotal = new PointPairList();
        public PointPairList ListPhiAntenna = new PointPairList();
        public PointPairList ListThetaAntenna = new PointPairList();
        public PointPairList ListTotalAntenna = new PointPairList();
        public PointPairList ListPhiReflaction = new PointPairList();
        public PointPairList ListThetaReflaction = new PointPairList();
        public PointPairList ListTotalReflaction = new PointPairList();
        public PointPairList ListPhiReflactionTrans = new PointPairList();
        public PointPairList ListThetaReflactionTrans = new PointPairList();
        public PointPairList ListTotalReflactionTrans = new PointPairList();
        public PointPairList ListPhiTotal = new PointPairList();
        public PointPairList ListThetaTotal = new PointPairList();
        public PointPairList ListTotalTotal = new PointPairList();
        public PointPairList ListM1 = new PointPairList();
        private List<PointPairList> ListPointPair = new List<PointPairList>();

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public Graph()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            ListPointPair.Clear();
            ListPointPair.Add(ListPhi);
            ListPointPair.Add(ListTheta);
            ListPointPair.Add(ListTotal);
            ListPointPair.Add(ListPhiAntenna);
            ListPointPair.Add(ListThetaAntenna);
            ListPointPair.Add(ListTotalAntenna);
            ListPointPair.Add(ListPhiReflaction);
            ListPointPair.Add(ListThetaReflaction);
            ListPointPair.Add(ListTotalReflaction);
            ListPointPair.Add(ListPhiReflactionTrans);
            ListPointPair.Add(ListThetaReflactionTrans);
            ListPointPair.Add(ListTotalReflactionTrans);
            ListPointPair.Add(ListPhiReflactionTrans);
            ListPointPair.Add(ListThetaTotal);
            ListPointPair.Add(ListTotalTotal);
            ListPointPair.Add(ListM1);
            int n = ListPointPair.Count;
            for (int i = 0; i < n; i++)
            {
                ListPointPair[i].Clear();
            }

            myPane = this.GraphPane;
            // Set the titles and axis labels
            //myPane.Chart.Border.Color = System.Drawing.SystemColors.Control;
            //myPane.Fill.Type = FillType.Solid;
            myPane.Fill.Color = System.Drawing.SystemColors.Control;
            myPane.Chart.Fill.Color = System.Drawing.SystemColors.Control;

            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";
            myPane.Legend.IsVisible = false;

            //myPane.YAxis.Cross = 0.0;
            // Turn off the axis frame and all the opposite side tics
            myPane.Chart.Border.IsVisible = false;
            myPane.XAxis.MajorTic.IsOpposite = false;
            myPane.XAxis.MinorTic.IsOpposite = false;
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;



            // Включаем отображение сетки напротив крупных рисок по оси X
            myPane.XAxis.MajorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси X:
            // Длина штрихов равна 10 пикселям, ... 
            myPane.XAxis.MajorGrid.DashOn = 10;

            // затем 5 пикселей - пропуск
            myPane.XAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив крупных рисок по оси Y
            myPane.YAxis.MajorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            myPane.YAxis.MajorGrid.DashOn = 10;
            myPane.YAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив мелких рисок по оси X
            myPane.YAxis.MinorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси Y: 
            // Длина штрихов равна одному пикселю, ... 
            myPane.YAxis.MinorGrid.DashOn = 1;

            // затем 2 пикселя - пропуск
            myPane.YAxis.MinorGrid.DashOff = 2;

            // Включаем отображение сетки напротив мелких рисок по оси Y
            myPane.XAxis.MinorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            myPane.XAxis.MinorGrid.DashOn = 1;
            myPane.XAxis.MinorGrid.DashOff = 2;

            BorderStyle = System.Windows.Forms.BorderStyle.None;
            myPane.Border.IsVisible = false;

            // Зделаем чуть помальче шрифт, чтобы уместилось побольше меток
            myPane.XAxis.Scale.FontSpec.Size = 10;
            myPane.YAxis.Scale.FontSpec.Size = 10;

            // Разрешим выбор кривых
            IsEnableSelection = true;

            // Выбирать кривые будем с помощью левой кнопки мыши
            SelectButtons = MouseButtons.Left;
            // При этом клавиши нажимать никакие не надо
            SelectModifierKeys = Keys.Shift;

            // Отключим масштабирование, так как по умолчанию 
            // оно тоже использует левую кнопку мыши без дополнительных клавиш
            //zedGraphControl1.IsEnableZoom = false;

            //цвет полотна графика
            //zedGraphControl1.GraphPane.Fill.Color = Color.White;
            //zedGraphControl1.GraphPane.Chart.Fill.Color = Color.White;

            myPane.CurveList.Clear();



            curvePhi = myPane.AddCurve("Phi", ListPhi, ColorPhi, SymbolType.Circle);
            curveTheta = myPane.AddCurve("Theta", ListTheta, ColorTheta, SymbolType.Circle);
            curveTotal = myPane.AddCurve("Total", ListTotal, ColorTotal, SymbolType.Circle);

            curvePhiAntenna = myPane.AddCurve("PhiAntenna", ListPhiAntenna, ColorPhiA, SymbolType.Circle);
            curveThetaAntenna = myPane.AddCurve("ThetaAntenna", ListThetaAntenna, ColorThetaA, SymbolType.Circle);
            curveTotalAntenna = myPane.AddCurve("TotalAntenna", ListTotalAntenna, ColorTotalA, SymbolType.Circle);

            curvePhiReflaction = myPane.AddCurve("PhiReflaction", ListPhiReflaction, ColorPhiR, SymbolType.Circle);
            curveThetaReflaction = myPane.AddCurve("ThetaReflaction", ListThetaReflaction, ColorThetaR, SymbolType.Circle);
            curveTotalReflaction = myPane.AddCurve("TotalReflaction", ListTotalReflaction, ColorTotalR, SymbolType.Circle);

            curvePhiReflactionTrans = myPane.AddCurve("PhiReflactionTrans", ListPhiReflactionTrans, ColorPhiRT, SymbolType.Circle);
            curveThetaReflactionTrans = myPane.AddCurve("ThetaReflactionTrans", ListThetaReflactionTrans, ColorThetaRT, SymbolType.Circle);
            curveTotalReflactionTrans = myPane.AddCurve("TotalReflactionTrans", ListTotalReflactionTrans, ColorTotalRT, SymbolType.Circle);

            curvePhiTotal = myPane.AddCurve("PhiFull", ListPhiTotal, ColorPhiT, SymbolType.Circle);
            curveThetaTotal = myPane.AddCurve("ThetaFull", ListThetaTotal, ColorThetaT, SymbolType.Circle);
            curveTotalTotal = myPane.AddCurve("TotalFull", ListTotalTotal, ColorTotalT, SymbolType.Circle);

            memoryCurve1 = myPane.AddCurve("MemoryCurve1", ListM1, ColorM1, SymbolType.Circle);

            curvePhi.Line.Width = 2F;
            curvePhi.Symbol.Size = 2F;

            curveTheta.Line.Width = 2F;
            curveTheta.Symbol.Size = 2F;

            curveTotal.Line.Width = 2F;
            curveTotal.Symbol.Size = 2F;

            curvePhiAntenna.Line.Width = 2F;
            curvePhiAntenna.Symbol.Size = 2F;

            curveThetaAntenna.Line.Width = 2F;
            curveThetaAntenna.Symbol.Size = 2F;

            curveTotalAntenna.Line.Width = 2F;
            curveTotalAntenna.Symbol.Size = 2F;

            curvePhiReflaction.Line.Width = 2F;
            curvePhiReflaction.Symbol.Size = 2F;

            curveThetaReflaction.Line.Width = 2F;
            curveThetaReflaction.Symbol.Size = 2F;

            curveTotalReflaction.Line.Width = 2F;
            curveTotalReflaction.Symbol.Size = 2F;

            curvePhiReflactionTrans.Line.Width = 2F;
            curvePhiReflactionTrans.Symbol.Size = 2F;

            curveThetaReflactionTrans.Line.Width = 2F;
            curveThetaReflactionTrans.Symbol.Size = 2F;

            curveTotalReflactionTrans.Line.Width = 2F;
            curveTotalReflactionTrans.Symbol.Size = 2F;

            curvePhiTotal.Line.Width = 2F;
            curvePhiTotal.Symbol.Size = 2F;

            curveThetaTotal.Line.Width = 2F;
            curveThetaTotal.Symbol.Size = 2F;

            curveTotalTotal.Line.Width = 2F;
            curveTotalTotal.Symbol.Size = 2F;

            memoryCurve1.Line.Width = 2F;
            memoryCurve1.Symbol.Size = 2F;

            int num = myPane.CurveList.Count();
            for (int i = 0; i < num; i++)
            {
                myPane.CurveList[i].IsVisible = false;
            }     
        }
        public void ListClear()
        {
            ListPhi.Clear();
            ListTheta.Clear();
            ListTotal.Clear();
            ListPhiAntenna.Clear();
            ListThetaAntenna.Clear();
            ListTotalAntenna.Clear();
            ListPhiReflaction.Clear();
            ListThetaReflaction.Clear();
            ListTotalReflaction.Clear();
            ListPhiReflactionTrans.Clear();
            ListThetaReflactionTrans.Clear();
            ListTotalReflactionTrans.Clear();
            ListPhiTotal.Clear();
            ListThetaTotal.Clear();
            ListTotalTotal.Clear();
        }
    }
}
