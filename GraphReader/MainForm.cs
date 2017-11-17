using GraphReader.Classes;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace GraphReader
{
    public partial class MainForm : Form
    {
        private TextReader TextReader;
        private TableWriter TableWriter;
        private NumbPad NumbPad;
        private Info GraphInfo = new Info();
        bool breaking;
        private int lastAddedValue = 0;
        private DateTime lastLoading;
        private int firstVisibleRow;
        private ScrollBars gridScrollBars;
        int NumberOfLines = 0;
        int SkipLines = 0;
        public int NumberOfColumns;
        int MassivesDataLines;
        int ScrollRange = 500;
        String Delimeter;
        public DataElement DataBase;
        public StringTable StringTable = new StringTable();
        List<String> DataMassive;
        private GraphPane myPane = new GraphPane();
        private int LastFileIndex = -1;
        private String LastFileAdress = "";
        private bool Checking = false;
        float Start;
        float Finish;
        float Step;
        bool Loading = false;
        TextBox[] TextBoxRange = new TextBox[3];
        System.Windows.Forms.CheckBox[] CheckBoxRange = new System.Windows.Forms.CheckBox[3];
        int SizeHeight;
        int SizeWidth;
        public const string version = "1.5";
        public string date = "08.11.17";

        #region ProgramInitialization
        public MainForm()
        {
            InitializeComponent();
            InitializeDataGrid();
            InitializeGraph();
            InitializeTreeViewMenu();

            treeView1.Nodes.Clear();
            TextBoxRange[0] = textBoxStart;
            TextBoxRange[1] = textBoxFinish;
            TextBoxRange[2] = textBoxStep;

            CheckBoxRange[0] = checkBoxAutoStart;
            CheckBoxRange[1] = checkBoxAutoFinish;
            CheckBoxRange[2] = checkBoxAutoStep;

            comboBox1.SelectedIndex = 0;
            textBoxExportPath.Text = Environment.CurrentDirectory.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += version;
        }
        private void InitializeTreeViewMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem expandLabel = new ToolStripMenuItem();
            expandLabel.Text = "Развернуть";
            expandLabel.Click += new EventHandler(treeView_Expand);

            ToolStripMenuItem collapseLabel = new ToolStripMenuItem();
            collapseLabel.Text = "Cвернуть";
            collapseLabel.Click += new EventHandler(treeView_Collapse);

            ToolStripMenuItem addLabel = new ToolStripMenuItem();
            addLabel.Text = "Открыть/Добавить";
            addLabel.Click += new EventHandler(treeView_Add);

            ToolStripMenuItem clearLabel = new ToolStripMenuItem();
            clearLabel.Text = "Очистить список";
            clearLabel.Click += new EventHandler(treeView_Clear);

            menu.Items.AddRange(new ToolStripMenuItem[] { addLabel, expandLabel, collapseLabel, clearLabel });
            treeView1.ContextMenuStrip = menu;
        }
        private void InitializeDataGrid()
        {
            //load firs 100 rows
            LoadRows();

        }
        private void InitializeGraph()
        {
            myPane = zedGraphControl1.GraphPane;
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
            myPane.Chart.Border.IsVisible = true;
            myPane.XAxis.MajorTic.IsOpposite = true;
            myPane.XAxis.MinorTic.IsOpposite = true;
            myPane.YAxis.MajorTic.IsOpposite = true;
            myPane.YAxis.MinorTic.IsOpposite = true;



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

            zedGraphControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            myPane.Border.IsVisible = false;

            // Зделаем чуть помальче шрифт, чтобы уместилось побольше меток
            myPane.XAxis.Scale.FontSpec.Size = 10;
            myPane.YAxis.Scale.FontSpec.Size = 10;

            // Разрешим выбор кривых
            zedGraphControl1.IsEnableSelection = true;

            // Выбирать кривые будем с помощью левой кнопки мыши
            zedGraphControl1.SelectButtons = MouseButtons.Left;
            // При этом клавиши нажимать никакие не надо
            zedGraphControl1.SelectModifierKeys = Keys.Shift;

            // Отключим масштабирование, так как по умолчанию 
            // оно тоже использует левую кнопку мыши без дополнительных клавиш
            //zedGraphControl1.IsEnableZoom = false;


            //цвет полотна графика
            //zedGraphControl1.GraphPane.Fill.Color = Color.White;
            zedGraphControl1.GraphPane.Chart.Fill.Color = Color.White;


            // Шторки
            PointPairList listLeft = new PointPairList();
            PointPairList listRight = new PointPairList();

            listLeft.Add(2, 0);
            listLeft.Add(2, 10);

            listRight.Add(10, 0);
            listRight.Add(10, 10);

            Random r = new Random();
            LineItem Left_curve = myPane.AddCurve("LeftGate", listLeft, Color.Red, SymbolType.None);
            LineItem Right_curve = myPane.AddCurve("RightGate", listRight, Color.Red, SymbolType.None);

            Left_curve.Tag = "Border";
            Right_curve.Tag = "Border";

            myPane.CurveList[myPane.CurveList.IndexOf("RightGate")].IsVisible = false;
            myPane.CurveList[myPane.CurveList.IndexOf("LeftGate")].IsVisible = false;

            Left_curve.Line.Width = 2F;
            Left_curve.Symbol.Size = 2F;

            Right_curve.Line.Width = 2F;
            Right_curve.Symbol.Size = 2F;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            zedGraphControl1.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(GraphContextRebuilder);
        }
        private void InitializeComboBoxes()
        {
            comboBoxX.SelectedIndex = 0;
            comboBoxY.SelectedIndex = 1;
        }
        private void GraphContextRebuilder(ZedGraphControl sender, ContextMenuStrip menuStrip, System.Drawing.Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            // !!! 
            // Переименуем (переведем на русский язык) некоторые пункты контекстного меню
            menuStrip.Items[0].Text = "Копировать";
            menuStrip.Items[1].Text = "Сохранить как картинку";
            menuStrip.Items[2].Text = "Параметры страницы";
            menuStrip.Items[3].Text = "Обновить";
            menuStrip.Items[4].Text = "Показать значение точек";
            menuStrip.Items[5].Text = "Отменить последнее масштабирование";
            menuStrip.Items[6].Text = "Отменить все масштабирование";
            menuStrip.Items[7].Text = "Установить масштаб по умолчанию";

            menuStrip.Items.RemoveAt(2);
            menuStrip.Items.RemoveAt(2);

            ToolStripMenuItem refresh = new ToolStripMenuItem();
            refresh.Text = "Обновить";
            refresh.Click += new EventHandler(ReDrawAllGraphs);
            menuStrip.Items.Add(refresh);

        }
        #endregion

        #region TreeViewFunctions
        private void treeView_Clear(object sender, EventArgs e)
        {
            if (!(treeView1.Nodes.Count == 0))
            {
                if (MessageBox.Show("Вы уверены, что хотите очистить список файлов?", "Подтверждение", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Loading = true;
                    MassivesDataLines = 0;
                    LoadEmptyRows();
                    treeView1.Nodes.Clear();
                    myPane.CurveList.Clear();
                    zedGraphControl1.Invalidate();
                    textBoxFileName.Text = "";
                    textBoxStart.Text = "";
                    textBoxFinish.Text = "";
                    textBoxStep.Text = "";
                    GraphInfo.Clear();
                    BoxLock(0);         // залочить поле старт
                    BoxLock(1);         // залочить поле финиш
                    BoxLock(2);         // залочить поле шаг
                    Loading = false;
                }
            }
        }
        private void treeView_Add(object sender, EventArgs e)
        {
            OpenFileScenario();
        }
        private void treeView_Expand(object sender, EventArgs e)
        {
            if (!(treeView1.Nodes.Count == 0))
            {
                treeView1.ExpandAll();
            }
        }
        private void treeView_Collapse(object sender, EventArgs e)
        {
            if (!(treeView1.Nodes.Count == 0))
            {
                treeView1.CollapseAll();
            }
        }
        private void treeView_addAllGraph(object sender, EventArgs e)
        {
            //treeView1.ExpandAll();
            for (int i = 1; i < treeView1.Nodes.Count; i++)
            {
                treeView1.Nodes[i].Checked = true;
            }
        }
        private void treeView_addAllMedian(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            for (int i = 1; i < treeView1.Nodes.Count; i++)
            {
                treeView1.Nodes[i].Nodes[0].Checked = true;
            }
        }
        private void treeView_removeAllMedian(object sender, EventArgs e)
        {
            for (int i = 1; i < treeView1.Nodes.Count; i++)
            {
                treeView1.Nodes[i].Nodes[0].Checked = false;
            }
        }
        private void treeView_removeAllGraph(object sender, EventArgs e)
        {
            for (int i = 1; i < treeView1.Nodes.Count; i++)
            {
                treeView1.Nodes[i].Checked = false;
            }
        }
        private void treeView_addAllMiddle(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            for (int i = 1; i < treeView1.Nodes.Count; i++)
            {
                treeView1.Nodes[i].Nodes[1].Checked = true;
            }
        }
        private void treeView_removeAllMiddle(object sender, EventArgs e)
        {
            for (int i = 1; i < treeView1.Nodes.Count; i++)
            {
                treeView1.Nodes[i].Nodes[1].Checked = false;
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool selection = false;
            String tag = e.Node.Text;
            if (tag == "(Выделить все)" || tag == "(Все медианные)" || tag == "(Все средние)")
            {
                selection = true;
            }
            if (!(Checking) && e.Node.Parent == null &&!selection)
            {
                String newFileAdress = e.Node.Text;
                LastFileIndex = e.Node.Index;
                LastFileAdress = newFileAdress;
                ShowData(LastFileIndex);

                if (breaking)
                {
                    InitializeComboBoxes();
                }
                else
                {
                    RefreshPanelInfo();
                }
            }
        }

        private bool AfterCheckSelectionScenario(object sender, TreeViewEventArgs e)
        {
            bool selection = false;
            String tag = e.Node.Text;
            if (tag == "(Выделить все)" || tag == "(Все медианные)" || tag == "(Все средние)")
            {
                selection = true;
            }
            if (selection)
            {
                if (tag == "(Выделить все)")
                {
                    if (e.Node.Checked)
                    {
                        Checking = false;
                        treeView_addAllGraph(sender, e);
                        Checking = true;
                    }
                    else
                    {
                        Checking = false;
                        treeView_removeAllGraph(sender, e);
                        Checking = true;
                    }
                }
                else if (tag == "(Все медианные)")
                {
                    if (e.Node.Checked)
                    {
                        Checking = false;
                        treeView_addAllMedian(sender, e);
                        Checking = true;
                    }
                    else
                    {
                        Checking = false;
                        treeView_removeAllMedian(sender, e);
                        Checking = true;
                    }
                }
                else if (tag == "(Все средние)")
                {
                    if (e.Node.Checked)
                    {
                        Checking = false;
                        treeView_addAllMiddle(sender, e);
                        Checking = true;
                    }
                    else
                    {
                        Checking = false;
                        treeView_removeAllMiddle(sender, e);
                        Checking = true;
                    }
                }
            }
            return selection;
        }
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {            
            if (!(Checking))
            {
                Checking = true;
                String newFileAdress = "";
                bool selection = AfterCheckSelectionScenario(sender, e);
                if (!selection)
                {
                    if (e.Node.Parent == null)
                    {
                        newFileAdress = e.Node.Text;

                        if (e.Node.Checked)
                        {
                            LastFileAdress = newFileAdress;
                            FileReading(LastFileAdress);

                            if (!(breaking))
                            {
                                RefreshPanelInfo();
                                if (checkBox_dB.Checked)
                                {
                                    GraphAddLog(sender, e);
                                }
                                else
                                {
                                    GraphAdd();
                                }
                            }
                            else
                            {
                                Checking = true;
                                e.Node.Checked = false;
                            }
                            if (!breaking)
                            {
                                DrawSheelds();
                            }
                        }
                        else
                        {
                            treeView1.Nodes[0].Checked = false;
                            GraphRemove(newFileAdress);
                        }                        
                    }
                    else if (e.Node.Text == "Среднее значение" || e.Node.Text == "Медианное значение")
                    {
                        newFileAdress = e.Node.Parent.Text;
                        if (e.Node.Checked)
                        {
                            LastFileAdress = newFileAdress;
                            FileReading(LastFileAdress);
                            if (!breaking)
                            {
                                AutoRangePanelInfo();
                            }
                            if (!(breaking))
                            {
                                DataBase.Compile(Start, Finish, Step);
                                breaking = DataBase.Break;
                            }
                            if (!breaking)
                            {

                                if (e.Node.Text == "Среднее значение")
                                {
                                    if (checkBox_dB.Checked)
                                    {
                                        AddMiddleGraphLog(sender, e);
                                    }
                                    else
                                    {
                                        AddMiddleGraph();
                                    }

                                }
                                else if (e.Node.Text == "Медианное значение")
                                {
                                    if (checkBox_dB.Checked)
                                    {
                                        AddMedianGraphLog(sender, e);
                                    }
                                    else
                                    {
                                        AddMedianGraph();
                                    }

                                }
                            }
                            else
                            {
                                Checking = true;
                                e.Node.Checked = false;
                            }
                            if (!breaking)
                            {
                                DrawSheelds();
                            }
                        }
                        else
                        {
                            if (e.Node.Text == "Среднее значение")
                            {
                                treeView1.Nodes[0].Nodes[1].Checked = false;
                                RemoveMiddleGraph(newFileAdress.Remove(newFileAdress.IndexOf(".")) + "_middle.txt");
                            }
                            else if (e.Node.Text == "Медианное значение")
                            {
                                treeView1.Nodes[0].Nodes[0].Checked = false;
                                RemoveMedianGraph(newFileAdress.Remove(newFileAdress.IndexOf(".")) + "_median.txt");
                            }
                        }                        
                    }                    
                }
                treeView1.SelectedNode = null;
                Checking = false;
                if (!selection)
                {                    
                    Checking = true;
                    treeView1.Nodes[0].Checked = CheckIfAllAreSelected();
                    treeView1.Nodes[0].Nodes[0].Checked = CheckIfAllMedianAreSelected();
                    treeView1.Nodes[0].Nodes[1].Checked = CheckIfAllMiddleAreSelected();
                    Checking = false;
                }                
            }
        }
        private bool CheckIfAllMedianAreSelected()
        {
            bool answer = true;
            for (int i = 1; i < treeView1.Nodes.Count; i++)
            {
                if (treeView1.Nodes[i].Nodes[0].Checked == false)
                {
                    answer = false;
                }
            }
            return answer;
        }
        private bool CheckIfAllMiddleAreSelected()
        {
            bool answer = true;
            for (int i = 1; i < treeView1.Nodes.Count; i++)
            {
                if (treeView1.Nodes[i].Nodes[1].Checked == false)
                {
                    answer = false;
                }
            }
            return answer;
        }
        private bool CheckIfAllAreSelected()
        {
            bool answer = true;
            for (int i = 1; i < treeView1.Nodes.Count; i++)
            {
                if (treeView1.Nodes[i].Checked == false)
                {
                    answer = false;
                }                
            }
            return answer;
        }
        private void ContextMenu_Open(object sender, EventArgs e)
        {
            String openFileName = (sender as ToolStripMenuItem).Tag.ToString();

            TextReader = new TextReader();
            TextReader.Show();
            TextReader.FileName = openFileName;
            TextReader.OpenScenario(openFileName);
        }
        private void ContextMenu_Delete(object sender, EventArgs e)
        {
            String deleteFileName = (sender as ToolStripMenuItem).Tag.ToString();

            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Text == deleteFileName)
                {
                    int deleteIndex = node.Index;
                    treeView1.Nodes.RemoveAt(deleteIndex);
                    if (node.Checked)
                    {
                        GraphRemove(deleteFileName);
                    }
                    if (node.Nodes[0].Checked)
                    {
                        RemoveMedianGraph(deleteFileName.Remove(deleteFileName.IndexOf(".")) + "_median");
                    }
                    if (node.Nodes[1].Checked)
                    {
                        RemoveMiddleGraph(deleteFileName.Remove(deleteFileName.IndexOf(".")) + "_middle");
                    }
                    LastFileIndex = -1;
                    LastFileAdress = "";
                    LoadEmptyRows();
                    break;
                }
            }
            treeView1.SelectedNode = null;
        }

        #endregion

        #region StripMenuPanel
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileScenario();
        }
        private void открытьTextReaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextReader = new TextReader();
            TextReader.Show();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void графикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (графикToolStripMenuItem.Checked)
            {
                if (splitContainer2.Panel2Collapsed)
                {
                    splitContainer2.Panel2Collapsed = false;
                    splitContainer1.Panel1Collapsed = true;
                    splitContainer1.Panel2Collapsed = false;
                    MaximizeToWindows();
                }
                else
                {
                    splitContainer1.Panel2Collapsed = false;
                }
            }
            else
            {
                if (листToolStripMenuItem.Checked)
                {
                    splitContainer1.Panel2Collapsed = true;
                }
                else
                {
                    MinimizeToInfoWindow();
                }

            }
        }
        private void листToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (листToolStripMenuItem.Checked)
            {

                if (splitContainer2.Panel2Collapsed)
                {
                    splitContainer2.Panel2Collapsed = false;
                    splitContainer1.Panel1Collapsed = false;
                    splitContainer1.Panel2Collapsed = true;
                    MaximizeToWindows();
                }
                else
                {
                    splitContainer1.Panel1Collapsed = false;
                }
            }
            else
            {
                if (графикToolStripMenuItem.Checked)
                {
                    splitContainer1.Panel1Collapsed = true;
                }
                else
                {
                    MinimizeToInfoWindow();
                }
            }
        }

        private void выбратьВсеГрафикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Checked = true;
        }

        private void выбратьВсеМедианныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes[0].Checked = true;
        }

        private void выбратьВсеСредниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes[1].Checked = true;
        }

        private void снятьВсеГрафикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Checked = false;
        }

        private void снятьВсеМедианныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes[0].Checked = false;
        }

        private void снятьВсеСредниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes[1].Checked = false;
        }

        private void открытьTableWriterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableWriter = new TableWriter(this);
            TableWriter.Show();
        }

        private void преобразоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNumbPad();
        }

        private void текстовыйРедакторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextReader = new TextReader();
            TextReader.Show();
            if (!(LastFileIndex == -1))
            {
                TextReader.FileName = LastFileAdress;
                TextReader.OpenScenario(LastFileAdress);
            }

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Программа GraphReader v" + version + " предназначена для визуализации табличных данных, а также их последующей обработки и редактирования \n\nПрограмма позволяет выгружать результаты обработки в виде *.docx и *.txt файлов: \n\t- средних значений \n\t- медианных значений \n\t- контрольных значений \n\nДата сборки текущей версии " + date + "";
            MessageBox.Show(message, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region DataGrid
        private void HideScrollBars()
        {
            gridScrollBars = dataGridView1.ScrollBars;
            dataGridView1.ScrollBars = ScrollBars.None;
        }
        private void ShowScrollBars()
        {
            dataGridView1.ScrollBars = gridScrollBars;
        }
        private int GetDisplayedRowsCount()
        {
            int count = dataGridView1.Rows[dataGridView1.FirstDisplayedScrollingRowIndex].Height;
            count = dataGridView1.Height / count;
            return count;
        }
        public void FirstLoadRows()
        {
            firstVisibleRow = 0;
            lastAddedValue = 0;
            ScrollRange = 500;
            dataGridView1.Rows.Clear();
            LoadRows();
        }
        private void LoadRows()
        {
            int dataLines = StringTable.RowsCount;
            if (!(lastAddedValue == dataLines) || dataLines == 0)
            {
                HideScrollBars();

                //System.Diagnostics.Debug.WriteLine("Load data");
                lastLoading = DateTime.Now;

                //create rows
                if (dataLines > 0 && !(breaking))
                {
                    if (lastAddedValue + ScrollRange <= dataLines)
                    {
                        for (int i = lastAddedValue; i < ScrollRange + lastAddedValue; i++)
                        {
                            dataGridView1.Rows.Add();
                            for (int j = 0; j < NumberOfColumns; j++)
                            {
                                dataGridView1[j, i].Value = StringTable.Cell[j, i];
                            }
                        }
                        lastAddedValue += ScrollRange;
                        ScrollRange = ScrollRange * 2;
                    }
                    else
                    {
                        int val = dataLines - lastAddedValue;

                        for (int i = lastAddedValue; i < lastAddedValue + val; i++)
                        {
                            dataGridView1.Rows.Add();
                            for (int j = 0; j < NumberOfColumns; j++)
                            {
                                dataGridView1[j, i].Value = StringTable.Cell[j, i];
                            }
                        }
                        lastAddedValue += val;
                    }
                }
                else
                {
                    for (int i = 0; i < ScrollRange; i++)
                    {
                        dataGridView1.Rows.Add();
                    }
                }


                //reset displayed row
                if (firstVisibleRow > -1)
                {
                    ShowScrollBars();
                    dataGridView1.FirstDisplayedScrollingRowIndex = firstVisibleRow;
                }
            }
        }
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
            {
                if (e.NewValue >= dataGridView1.Rows.Count - GetDisplayedRowsCount())
                {
                    //prevent loading from autoscroll.
                    TimeSpan ts = DateTime.Now - lastLoading;
                    if (ts.TotalMilliseconds > 100)
                    {
                        firstVisibleRow = e.NewValue;
                        LoadRows();
                    }
                    else
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = e.OldValue;
                    }
                }
            }
        }
        private void LoadEmptyRows()
        {
            HideScrollBars();

            firstVisibleRow = 0;
            lastAddedValue = 0;
            ScrollRange = 500;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ScrollRange; i++)
            {
                dataGridView1.Rows.Add();
            }

            if (firstVisibleRow > -1)
            {
                ShowScrollBars();
                dataGridView1.FirstDisplayedScrollingRowIndex = firstVisibleRow;
            }
        }
        private void ShowData(int showFileNumber)
        {
            if (!(Checking))
            {
                String fileAdress = treeView1.Nodes[showFileNumber].Text;
                comboBoxX.SelectedIndex = 0;
                comboBoxY.SelectedIndex = 1;
                FileReading(fileAdress);
                FirstLoadRows();

                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!(treeView1.Nodes.Count == 0))
            {
                ShowData(LastFileIndex);
            }
        }
        #endregion

        #region TabControl
        private void BoxLock(int num)
        {
            CheckBoxRange[num].Checked = true;
            TextBoxRange[num].BackColor = System.Drawing.SystemColors.Control;
        }
        private void BoxUnLock(int num)
        {
            CheckBoxRange[num].Checked = false;
            TextBoxRange[num].BackColor = System.Drawing.SystemColors.Window;
        }
        private void RefreshPanelInfo()
        {
            Loading = true;
            int colx = comboBoxX.SelectedIndex;
            int coly = comboBoxY.SelectedIndex;

            textBoxFileName.Text = LastFileAdress;

            object[] alfa = new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S" };
            comboBoxX.Items.Clear();
            comboBoxY.Items.Clear();

            for (int i = 0; i < NumberOfColumns; i++)
            {
                comboBoxX.Items.Add(alfa[i]);
                comboBoxY.Items.Add(alfa[i]);
            }
            comboBoxX.SelectedIndex = colx;
            comboBoxY.SelectedIndex = coly;

            AutoRangePanelInfo();

            Loading = false;
        }
        private void AutoRangePanelInfo()
        {
            Loading = true;
            if (checkBoxAutoStart.Checked)
            {
                textBoxStart.Text = Convert.ToString(DataBase.Begin);
                Start = DataBase.Begin;

            }
            if (checkBoxAutoFinish.Checked)
            {

                textBoxFinish.Text = Convert.ToString(DataBase.End);
                Finish = DataBase.End;

            }
            if (checkBoxAutoStep.Checked)
            {

                textBoxStep.Text = Convert.ToString(Math.Floor((DataBase.End - DataBase.Begin) / 10));
                Step = (float)Math.Floor((DataBase.End - DataBase.Begin) / 10);

            }
            Loading = false;
        }
        private void checkBoxDelimeter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDelimeter.Checked)
            {
                comboBoxDelimeter.Enabled = false;
            }
            else
            {
                comboBoxDelimeter.Enabled = true;
                if (comboBoxDelimeter.Text == "")
                {
                    comboBoxDelimeter.SelectedIndex = 0;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!(myPane.CurveList.Count == 0))
            {
                string format = CallFormat(Convert.ToInt32(numericUpDownDecimalNumb.Value));
                String exportPath;
                exportPath = textBoxExportPath.Text;
                for (int i = 0; i < myPane.CurveList.Count; i++)
                {
                    if (myPane.CurveList[i].Tag.ToString() == "Median" || myPane.CurveList[i].Tag.ToString() == "Middle")
                    {
                        String name = myPane.CurveList[i].Label.Text.ToString();
                        String partName = name.Substring(name.LastIndexOf("\\"));
                        StreamWriter sw = new StreamWriter(exportPath + partName);

                        for (int j = 0; j < myPane.CurveList[i].Points.Count; j++)
                        {
                            Decimal yVal = Convert.ToDecimal(myPane.CurveList[i].Points[j].Y);
                            yVal = Math.Round(yVal, Convert.ToInt32(numericUpDownDecimalNumb.Value));
                            string line = myPane.CurveList[i].Points[j].X.ToString() + "\t" + String.Format(format, yVal);
                            if (comboBox1.SelectedIndex == 0)
                            {
                                line = line.Replace(",", ".");
                            }
                            sw.WriteLine(line);
                        }
                        sw.Close();
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!(myPane.CurveList.Count == 0))
            {
                if (ProveEqualBorders())
                {
                    WaitCursorON();

                    string format = CallFormat(Convert.ToInt32(numericUpDownDecimalNumb.Value));

                    List<List<String>> dataMassiveMedian = new List<List<String>>();
                    List<List<String>> dataMassiveMiddle = new List<List<String>>();

                    for (int i = 0; i < myPane.CurveList.Count; i++)
                    {
                        if (myPane.CurveList[i].Tag.ToString() == "Median" || myPane.CurveList[i].Tag.ToString() == "Middle")
                        {
                            List<string> firstRow = new List<string>();
                            firstRow.Add("");

                            for (int n = 1; n < myPane.CurveList[i].Points.Count; n = n + 2)
                            {
                                string firststr = myPane.CurveList[i].Points[n - 1].X.ToString();
                                string secondstr = myPane.CurveList[i].Points[n].X.ToString();

                                firstRow.Add(firststr + "..." + secondstr);
                            }
                            dataMassiveMedian.Add(firstRow);
                            dataMassiveMiddle.Add(firstRow);
                            break;
                        }
                    }



                    for (int i = 0; i < myPane.CurveList.Count; i++)
                    {
                        if (myPane.CurveList[i].Tag.ToString() == "Median")
                        {
                            List<String> dataRow = new List<string>();
                            String filename = myPane.CurveList[i].Label.Text.ToString();
                            String shortName = filename.Substring(filename.LastIndexOf("\\") + 1);
                            string sname = shortName.Remove(shortName.LastIndexOf("_"));
                            dataRow.Add(sname);

                            for (int j = 0; j < myPane.CurveList[i].Points.Count; j = j + 2)
                            {
                                Decimal val = Convert.ToDecimal(myPane.CurveList[i].Points[j].Y);
                                val = Math.Round(val, Convert.ToInt32(numericUpDownDecimalNumb.Value));
                                dataRow.Add(String.Format(format, val));
                            }
                            dataMassiveMedian.Add(dataRow);
                        }
                        else if (myPane.CurveList[i].Tag.ToString() == "Middle")
                        {
                            List<String> dataRow = new List<string>();
                            String filename = myPane.CurveList[i].Label.Text.ToString();
                            String shortName = filename.Substring(filename.LastIndexOf("\\") + 1);
                            string sname = shortName.Remove(shortName.LastIndexOf("_"));
                            dataRow.Add(sname);

                            for (int j = 0; j < myPane.CurveList[i].Points.Count; j = j + 2)
                            {
                                Decimal val = Convert.ToDecimal(myPane.CurveList[i].Points[j].Y);
                                val = Math.Round(val, Convert.ToInt32(numericUpDownDecimalNumb.Value));
                                dataRow.Add(String.Format(format, val));
                            }
                            dataMassiveMiddle.Add(dataRow);
                        }
                    }

                    CreateWordDocument(dataMassiveMedian, dataMassiveMiddle);
                    WaitCursorOFF();
                }
                else
                {
                    MessageBox.Show("Границы расчитанных значений не совпадают", "Ошибка", MessageBoxButtons.OK);
                }

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxExportPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void textBoxStart_TextChanged(object sender, EventArgs e)
        {
            if (!(Loading))
            {
                try
                {
                    BoxUnLock(0);
                    Start = Convert.ToSingle(textBoxStart.Text);
                    DrawSheelds();

                }
                catch (Exception)
                {
                }
            }

        }
        private void textBoxFinish_TextChanged(object sender, EventArgs e)
        {
            if (!(Loading))
            {
                try
                {
                    BoxUnLock(1);
                    Finish = Convert.ToSingle(textBoxFinish.Text);
                    DrawSheelds();
                }
                catch (Exception)
                {
                }
            }

        }
        private void textBoxStep_TextChanged(object sender, EventArgs e)
        {
            if (!(Loading))
            {
                try
                {
                    BoxUnLock(2);
                    Step = Convert.ToSingle(textBoxStep.Text);
                    DrawSheelds();
                }
                catch (Exception)
                {
                }
            }

        }
        private void checkBox_dB_CheckedChanged(object sender, EventArgs e)
        {
            if (!(breaking))
            {
                if (checkBox_dB.Checked)
                {
                    if (OnlyPositive(myPane.CurveList))
                    {
                        for (int i = 0; i < myPane.CurveList.Count; i++)
                        {
                            for (int j = 0; j < myPane.CurveList[i].Points.Count; j++)
                            {
                                myPane.CurveList[i].Points[j].Y = 20 * Math.Log10(myPane.CurveList[i].Points[j].Y);
                            }
                        }
                        zedGraphControl1.AxisChange();
                        zedGraphControl1.Invalidate();
                    }
                    else
                    {
                        breaking = true;
                        checkBox_dB.Checked = false;
                        breaking = false;
                        MessageBox.Show("Не все графики могуть быть нарисованы в логирифмической шкале.");

                    }
                }
                else
                {
                    for (int i = 0; i < myPane.CurveList.Count; i++)
                    {
                        for (int j = 0; j < myPane.CurveList[i].Points.Count; j++)
                        {
                            myPane.CurveList[i].Points[j].Y = Math.Pow(10, myPane.CurveList[i].Points[j].Y / 20);
                        }
                    }
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();
                }
            }
        }
        private void checkBoxAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoStart.Checked)
            {
                BoxLock(0);
                if (!(textBoxStart.Text == ""))
                {
                    AutoRangePanelInfo();
                    DrawSheelds();
                }

            }
            else
            {
                BoxUnLock(0);
            }
        }
        private void checkBoxAutoFinish_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoFinish.Checked)
            {
                BoxLock(1);
                if (!(textBoxFinish.Text == ""))
                {
                    AutoRangePanelInfo();
                    DrawSheelds();
                }
            }
            else
            {
                BoxUnLock(1);
            }
        }
        private void checkBoxAutoStep_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoStep.Checked)
            {
                BoxLock(2);
                if (!(textBoxStep.Text == ""))
                {
                    AutoRangePanelInfo();
                    DrawSheelds();
                }
            }
            else
            {
                BoxUnLock(2);
            }
        }
        private void checkBoxBorders_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBorders.Checked)
            {
                myPane.CurveList[myPane.CurveList.IndexOf("RightGate")].IsVisible = true;
                myPane.CurveList[myPane.CurveList.IndexOf("LeftGate")].IsVisible = true;
            }
            else
            {
                myPane.CurveList[myPane.CurveList.IndexOf("RightGate")].IsVisible = false;
                myPane.CurveList[myPane.CurveList.IndexOf("LeftGate")].IsVisible = false;
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void textBoxEnterNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45 && number != 46) // цифры, клавиша BackSpace
            {
                e.Handled = true;
            }
            if (!(number != 46))
            {
                e.KeyChar = ',';
            }
        }
        private bool ProveEqualBorders()
        {
            bool answer = true;
            Double start = new float();
            Double finish = new float();
            bool definition = true;
            for (int i = 0; i < myPane.CurveList.Count; i++)
            {
                if (myPane.CurveList[i].Tag.ToString() == "Median" || myPane.CurveList[i].Tag.ToString() == "Middle")
                {

                    if (definition)
                    {
                        definition = false;
                        start = myPane.CurveList[i].Points[0].X;
                        finish = myPane.CurveList[i].Points[myPane.CurveList[i].Points.Count - 1].X;
                    }
                    else
                    {
                        if (!(Math.Abs(start - myPane.CurveList[i].Points[0].X) < 0.00001) || !(Math.Abs(finish - myPane.CurveList[i].Points[myPane.CurveList[i].Points.Count - 1].X) < 0.00001))
                        {
                            answer = false;
                        }
                    }
                }
            }
            return answer;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45 && number != 46) // цифры, клавиша BackSpace
            {
                e.Handled = true;
            }
            if (!(number != 46))
            {
                e.KeyChar = ',';
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SkipLines = Convert.ToInt32(numericUpDownSkip.Value);
            }
            catch (Exception)
            {
            }
        }
        private void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHeader.Checked)
            {
                SkipLines = 0;
                numericUpDownSkip.Enabled = false;
            }
            else
            {
                numericUpDownSkip.Enabled = true;
                numericUpDownSkip.Value = 1;
                SkipLines = 1;
            }
        }
        #endregion

        #region GraphControl
        private void DrawSheelds()
        {
            if (!(DataBase.Values.Length == -1))
            {
                if (!(myPane.CurveList.IndexOf("LeftGate") == -1) && !(myPane.CurveList.IndexOf("RightGate") == -1))
                {
                    myPane.CurveList.RemoveAt(myPane.CurveList.IndexOf("LeftGate"));
                    myPane.CurveList.RemoveAt(myPane.CurveList.IndexOf("RightGate"));
                }
            }

            PointPairList listLeft = new PointPairList();
            PointPairList listRight = new PointPairList();

            if (!(checkBox_dB.Checked))
            {
                listLeft.Add(Start, GraphInfo.Min);
                listLeft.Add(Start, GraphInfo.Max);

                listRight.Add(Finish, GraphInfo.Min);
                listRight.Add(Finish, GraphInfo.Max);
            }
            else
            {
                listLeft.Add(Start, 20 * Math.Log10(GraphInfo.Min));
                listLeft.Add(Start, 20 * Math.Log10(GraphInfo.Max));

                listRight.Add(Finish, 20 * Math.Log10(GraphInfo.Min));
                listRight.Add(Finish, 20 * Math.Log10(GraphInfo.Max));
            }
                                   
            LineItem Left_curve = myPane.AddCurve("LeftGate", listLeft, Color.Red, SymbolType.None);
            LineItem Right_curve = myPane.AddCurve("RightGate", listRight, Color.Red, SymbolType.None);


            Left_curve.Line.Width = 1F;
            Left_curve.Symbol.Size = 2F;
            Left_curve.Tag = "Border";


            Right_curve.Line.Width = 1F;
            Right_curve.Symbol.Size = 2F;
            Right_curve.Tag = "Border";


            if (checkBoxBorders.Checked)
            {
                myPane.CurveList[myPane.CurveList.IndexOf("RightGate")].IsVisible = true;
                myPane.CurveList[myPane.CurveList.IndexOf("LeftGate")].IsVisible = true;
            }
            else
            {
                myPane.CurveList[myPane.CurveList.IndexOf("RightGate")].IsVisible = false;
                myPane.CurveList[myPane.CurveList.IndexOf("LeftGate")].IsVisible = false;
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void RemoveSheelds()
        {
            if (!(myPane.CurveList.IndexOf("LeftGate") == -1) && !(myPane.CurveList.IndexOf("RightGate") == -1))
            {
                myPane.CurveList.RemoveAt(myPane.CurveList.IndexOf("LeftGate"));
                myPane.CurveList.RemoveAt(myPane.CurveList.IndexOf("RightGate"));
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void GraphAdd()
        {
            String filename = DataBase.Title;
            if (!(GraphInfo.Exist(filename)))
            {
                PointPairList list = new PointPairList();
                for (int i = 0; i < MassivesDataLines; i++)
                {
                    list.Add(DataBase.Values[i, 0], DataBase.Values[i, 1]);
                }
                Random r = new Random();
                LineItem f1_curve = myPane.AddCurve(DataBase.Title, list, Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)), SymbolType.None);
                f1_curve.Line.Width = 2F;
                f1_curve.Symbol.Size = 2F;
                f1_curve.Tag = "Origin";

                GraphInfo.Add(filename, DataBase.Min, DataBase.Max);
                DrawSheelds();

                myPane.XAxis.Scale.MinAuto = true;
                myPane.XAxis.Scale.MaxAuto = true;
                myPane.YAxis.Scale.MinAuto = true;
                myPane.YAxis.Scale.MaxAuto = true;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }
        private void GraphAddLog(object sender, TreeViewEventArgs e)
        {
            String filename = DataBase.Title;
            if (!(GraphInfo.Exist(filename)))
            {
                if (OnlyPositive(DataBase.Values))
                {
                    try
                    {
                        PointPairList list = new PointPairList();
                        for (int i = 0; i < MassivesDataLines; i++)
                        {
                            list.Add(DataBase.Values[i, 0], 20 * Math.Log10(DataBase.Values[i, 1]));
                        }
                        Random r = new Random();
                        Random g = new Random();
                        LineItem f1_curve = myPane.AddCurve(filename, list, Color.FromArgb(r.Next(120), r.Next(256), r.Next(256)), SymbolType.None);
                        f1_curve.Line.Width = 2F;
                        f1_curve.Symbol.Size = 2F;
                        f1_curve.Tag = "Origin";

                        GraphInfo.Add(filename, DataBase.Min, DataBase.Max);
                        DrawSheelds();

                        myPane.XAxis.Scale.MinAuto = true;
                        myPane.XAxis.Scale.MaxAuto = true;
                        myPane.YAxis.Scale.MinAuto = true;
                        myPane.YAxis.Scale.MaxAuto = true;
                        zedGraphControl1.AxisChange();
                        zedGraphControl1.Invalidate();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Произошла неизвестная ошибка");
                    }
                }
                else
                {
                    breaking = true;
                    e.Node.Checked = false;
                    breaking = false;
                    MessageBox.Show("График " + filename + " не может быть наросован шкале дБ");
                }
            }
        }
        private void AddMiddleGraph()
        {
            String filename = DataBase.Title.Remove(DataBase.Title.LastIndexOf(".")) + "_middle.txt";
            if (!(GraphInfo.Exist(filename)))
            {
                PointPairList list = new PointPairList();
                for (int i = 0; i < DataBase.Sectors; i++)
                {
                    if (DataBase.Start + DataBase.Step * (i + 1) > Finish)
                    {
                        list.Add(DataBase.Start + DataBase.Step * i, DataBase.Middle[i]);
                        list.Add(Finish, DataBase.Middle[i]);
                    }
                    else
                    {
                        list.Add(DataBase.Start + DataBase.Step * i, DataBase.Middle[i]);
                        list.Add(DataBase.Start + DataBase.Step * (i + 1), DataBase.Middle[i]);
                    }
                }
                Random r = new Random();                
                String cutname = DataBase.Title.Remove(DataBase.Title.LastIndexOf("."));
                LineItem f1_curve = myPane.AddCurve(cutname + "_middle.txt", list, Color.FromArgb(r.Next(256), r.Next(120), r.Next(256)), SymbolType.None);
                f1_curve.Line.Width = 3F;
                f1_curve.Symbol.Size = 2F;
                f1_curve.Tag = "Middle";
                GraphInfo.Add(filename, DataBase.MiddleMin, DataBase.MiddleMax);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }
        private void AddMiddleGraphLog(object sender, TreeViewEventArgs e)
        {
            String filename = DataBase.Title.Remove(DataBase.Title.LastIndexOf(".")) + "_middle.txt";
            if (!(GraphInfo.Exist(filename)))
            {
                if (OnlyPositive(DataBase.Values))
                {
                    PointPairList list = new PointPairList();
                    for (int i = 0; i < DataBase.Sectors; i++)
                    {
                        if (DataBase.Start + DataBase.Step * (i + 1) > Finish)
                        {
                            list.Add(DataBase.Start + DataBase.Step * i, 20 * Math.Log10(DataBase.Middle[i]));
                            list.Add(Finish, 20 * Math.Log10(DataBase.Middle[i]));
                        }
                        else
                        {
                            list.Add(DataBase.Start + DataBase.Step * i, 20 * Math.Log10(DataBase.Middle[i]));
                            list.Add(DataBase.Start + DataBase.Step * (i + 1), 20 * Math.Log10(DataBase.Middle[i]));
                        }
                    }
                    Random r = new Random();
                    Random g = new Random();
                    String cutname = DataBase.Title.Remove(DataBase.Title.LastIndexOf("."));
                    LineItem f1_curve = myPane.AddCurve(cutname + "_middle.txt", list, Color.FromArgb(r.Next(256), r.Next(120), r.Next(256)), SymbolType.None);
                    f1_curve.Line.Width = 3F;
                    f1_curve.Symbol.Size = 2F;
                    f1_curve.Tag = "Middle";
                    GraphInfo.Add(filename, Convert.ToSingle(20 * Math.Log10(DataBase.MiddleMin)), Convert.ToSingle(20 * Math.Log10(DataBase.MiddleMax)));
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();
                }
                else
                {
                    breaking = true;
                    e.Node.Checked = false;
                    breaking = false;
                    MessageBox.Show("График " + filename + " не может быть наросован в логарифмической шкале");
                }
            }
        }
        private void AddMedianGraph()
        {
            String filename = DataBase.Title.Remove(DataBase.Title.LastIndexOf(".")) + "_median.txt";
            if (!(GraphInfo.Exist(filename)))
            {
                PointPairList list = new PointPairList();
                for (int i = 0; i < DataBase.Sectors; i++)
                {
                    if (DataBase.Start + DataBase.Step * (i + 1) > Finish)
                    {
                        list.Add(DataBase.Start + DataBase.Step * i, DataBase.Median[i]);
                        list.Add(DataBase.Finish, DataBase.Median[i]);
                    }
                    else
                    {
                        list.Add(DataBase.Start + DataBase.Step * i, DataBase.Median[i]);
                        list.Add(DataBase.Start + DataBase.Step * (i + 1), DataBase.Median[i]);
                    }

                }
                Random r = new Random();                
                String cutname = DataBase.Title.Remove(DataBase.Title.LastIndexOf("."));
                LineItem f1_curve = myPane.AddCurve(cutname + "_median.txt", list, Color.FromArgb(r.Next(256), r.Next(120), r.Next(256)), SymbolType.None);
                f1_curve.Line.Width = 3F;
                f1_curve.Symbol.Size = 2F;
                f1_curve.Tag = "Median";
                GraphInfo.Add(filename, DataBase.MedianMin, DataBase.MedianMax);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }
        private void AddMedianGraphLog(object sender, TreeViewEventArgs e)
        {
            String filename = DataBase.Title.Remove(DataBase.Title.LastIndexOf(".")) + "_median.txt";
            if (!(GraphInfo.Exist(filename)))
            {
                if (OnlyPositive(DataBase.Values))
                {
                    PointPairList list = new PointPairList();
                    for (int i = 0; i < DataBase.Sectors; i++)
                    {
                        if (DataBase.Start + DataBase.Step * (i + 1) > Finish)
                        {
                            list.Add(DataBase.Start + DataBase.Step * i, 20 * Math.Log10(DataBase.Median[i]));
                            list.Add(DataBase.Finish, 20 * Math.Log10(DataBase.Median[i]));
                        }
                        else
                        {
                            list.Add(DataBase.Start + DataBase.Step * i, 20 * Math.Log10(DataBase.Median[i]));
                            list.Add(DataBase.Start + DataBase.Step * (i + 1), 20 * Math.Log10(DataBase.Median[i]));
                        }

                    }
                    Random r = new Random();                    
                    String cutname = DataBase.Title.Remove(DataBase.Title.LastIndexOf("."));
                    LineItem f1_curve = myPane.AddCurve(cutname + "_median.txt", list, Color.FromArgb(r.Next(256), r.Next(120), r.Next(256)), SymbolType.None);
                    f1_curve.Line.Width = 3F;
                    f1_curve.Symbol.Size = 2F;
                    f1_curve.Tag = "Median";
                    GraphInfo.Add(filename, Convert.ToSingle(20 * Math.Log10(DataBase.MedianMin)), Convert.ToSingle(20 * Math.Log10(DataBase.MedianMax)));
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();
                }
                else
                {
                    breaking = true;
                    e.Node.Checked = false;
                    breaking = false;
                    MessageBox.Show("График " + filename + " не может быть наросован в логарифмической шкале");
                }
            }
        }
        private void GraphRemove(String removeGraphName)
        {
            if (GraphInfo.Exist(removeGraphName))
            {
                try
                {
                    myPane.CurveList.RemoveAt(myPane.CurveList.IndexOf(removeGraphName));
                    GraphInfo.Remove(removeGraphName);
                    RemoveSheelds();
                    Loading = true;
                    textBoxStart.Text = "";
                    textBoxFinish.Text = "";
                    textBoxStep.Text = "";
                    Loading = false;
                }
                catch (Exception)
                {

                    MessageBox.Show("Нет графика " + removeGraphName);
                }

                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }
        private void RemoveMiddleGraph(string removeGraphName)
        {
            if (GraphInfo.Exist(removeGraphName))
            {
                try
                {
                    myPane.CurveList.RemoveAt(myPane.CurveList.IndexOf(removeGraphName));
                    GraphInfo.Remove(removeGraphName);
                    RemoveSheelds();
                    Loading = true;
                    textBoxStart.Text = "";
                    textBoxFinish.Text = "";
                    textBoxStep.Text = "";
                    Loading = false;
                }
                catch (Exception)
                {

                    MessageBox.Show("Нет графика " + removeGraphName + "_middle.txt");
                }

                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }
        private void RemoveMedianGraph(string removeGraphName)
        {
            if (GraphInfo.Exist(removeGraphName))
            {
                try
                {
                    myPane.CurveList.RemoveAt(myPane.CurveList.IndexOf(removeGraphName));
                    GraphInfo.Remove(removeGraphName);
                    RemoveSheelds();
                    Loading = true;
                    textBoxStart.Text = "";
                    textBoxFinish.Text = "";
                    textBoxStep.Text = "";
                    Loading = false;
                }
                catch (Exception)
                {

                    MessageBox.Show("Произошла ошибка. Графика с именем" + removeGraphName + "_median.txt не найден.");
                }

                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }
        private void ReDrawAllGraphs(object sender, EventArgs e)
        {
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        #endregion

        #region Reading
        public void FileReading(String fileadress)
        {
            ReadingStep1(fileadress);
        }
        private void ReadingStep1(String fileAdress)
        {
            StreamReader sr = new StreamReader(fileAdress);
            NumberOfLines = 0;
            string varline = sr.ReadLine();
            while (varline != null)
            {
                if (!(varline == ""))
                {
                    NumberOfLines++;
                }
                varline = sr.ReadLine();
            }
            MassivesDataLines = NumberOfLines - SkipLines;
            DataMassive = new List<string>(MassivesDataLines);

            sr = new StreamReader(fileAdress);
            for (int i = 0; i < SkipLines; i++)
            {
                sr.ReadLine();
            }
            for (int i = 0; i < MassivesDataLines; i++)
            {
                DataMassive.Add(sr.ReadLine());
            }
            sr.Close();

            ReadingStep2(fileAdress);
        }
        private void ReadingStep2(String fileAdress)
        {
            //
            // Separator Determination
            //            
            breaking = false;

            if (checkBoxDelimeter.Checked)
            {
                String sline = DataMassive[0];
                String vline = sline;
                int NofTabs = 0;
                while (!(vline.IndexOf("\t") == -1))
                {
                    vline = vline.Substring(vline.IndexOf("\t") + 1);
                    NofTabs++;
                }
                vline = sline;
                int NofSpaces = 0;
                while (!(vline.IndexOf(" ") == -1))
                {
                    vline = vline.Substring(vline.IndexOf(" ") + 1);
                    NofSpaces++;
                }
                vline = sline;
                int NofSemiCal = 0;
                while (!(vline.IndexOf(";") == -1))
                {
                    vline = vline.Substring(vline.IndexOf(";") + 1);
                    NofSemiCal++;
                }
                vline = sline;
                int NofComma = 0;
                while (!(vline.IndexOf(",") == -1))
                {
                    vline = vline.Substring(vline.IndexOf(",") + 1);
                    NofComma++;
                }
                vline = sline;
                int NofPoints = 0;
                while (!(vline.IndexOf(".") == -1))
                {
                    vline = vline.Substring(vline.IndexOf(".") + 1);
                    NofPoints++;
                }

                int NofTabsNew;
                int NofSpacesNew;
                int NofSemiCalNew;
                int NofCommaNew;
                int NofPointsNew;
                int NumOfDelim = 0;

                for (int k = 1; k < MassivesDataLines; k++)
                {
                    sline = DataMassive[k];
                    vline = sline;
                    NofTabsNew = 0;
                    while (!(vline.IndexOf("\t") == -1))
                    {
                        vline = vline.Substring(vline.IndexOf("\t") + 1);
                        NofTabsNew++;
                    }

                    vline = sline;
                    NofSpacesNew = 0;
                    while (!(vline.IndexOf(" ") == -1))
                    {
                        vline = vline.Substring(vline.IndexOf(" ") + 1);
                        NofSpacesNew++;
                    }

                    vline = sline;
                    NofSemiCalNew = 0;
                    while (!(vline.IndexOf(";") == -1))
                    {
                        vline = vline.Substring(vline.IndexOf(";") + 1);
                        NofSemiCalNew++;
                    }

                    vline = sline;
                    NofCommaNew = 0;
                    while (!(vline.IndexOf(",") == -1))
                    {
                        vline = vline.Substring(vline.IndexOf(",") + 1);
                        NofCommaNew++;
                    }

                    vline = sline;
                    NofPointsNew = 0;
                    while (!(vline.IndexOf(".") == -1))
                    {
                        vline = vline.Substring(vline.IndexOf(".") + 1);
                        NofPointsNew++;
                    }
                    if (!(NofTabsNew == NofTabs))
                    {
                        NofTabs = 0;
                    }

                    if (!(NofSpacesNew == NofSpaces))
                    {
                        NofSpaces = 0;
                    }

                    if (!(NofSemiCalNew == NofSemiCal))
                    {
                        NofSemiCal = 0;
                    }

                    if (!(NofCommaNew == NofComma))
                    {
                        NofComma = 0;
                    }
                    NofPoints = NofPointsNew + NofPoints;

                    if (NofPoints > 0)
                    {
                        if (!(NofTabs == 0))
                        {
                            Delimeter = "\t";
                            NumOfDelim = NofTabs;
                        }
                        if (!(NofSpaces == 0))
                        {
                            Delimeter = " ";
                            NumOfDelim = NofSpaces;
                        }
                        if (!(NofSemiCal == 0))
                        {
                            Delimeter = ";";
                            NumOfDelim = NofSemiCal;
                        }
                        if (!(NofComma == 0))
                        {
                            Delimeter = ",";
                            NumOfDelim = NofComma;
                        }
                    }
                    else
                    {
                        if (!(NofTabs == 0))
                        {
                            Delimeter = "\t";
                            NumOfDelim = NofTabs;
                        }
                        if (!(NofSpaces == 0))
                        {
                            Delimeter = " ";
                            NumOfDelim = NofSpaces;
                        }
                        if (!(NofSemiCal == 0))
                        {
                            Delimeter = ";";
                            NumOfDelim = NofSemiCal;
                        }
                    }

                    if (NofTabs == 0 && NofSpaces == 0 && NofSemiCal == 0 && NofComma == 0)
                    {
                        MessageBox.Show("Не обнаружен разделитель столбцов. Попробуйте ввести разделитель столбцов вручную.", "Невозможно прочитать файл",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        breaking = true;
                        break;
                    }
                    if (sline.Substring(sline.LastIndexOf(Delimeter) + 1) == "")
                    {
                        NumberOfColumns = NumOfDelim;
                    }
                    else
                    {
                        NumberOfColumns = NumOfDelim + 1;
                    }
                }
            }
            else
            {
                string[] setDelimeter = { "\t", " ", ".", ",", ";" };
                Delimeter = setDelimeter[comboBoxDelimeter.SelectedIndex];
                String vline = DataMassive[0];
                String sline = vline;

                int NumOfDelim = 0;
                if (Delimeter == "")
                {
                    NumberOfColumns = 1;
                }
                else
                {
                    while (!(vline.IndexOf(Delimeter) == -1))
                    {
                        vline = vline.Substring(vline.IndexOf(Delimeter) + 1);
                        NumOfDelim++;
                    }

                    if (sline.Substring(sline.LastIndexOf(Delimeter) + 1) == "")
                    {
                        NumberOfColumns = NumOfDelim;
                    }
                    else
                    {
                        NumberOfColumns = NumOfDelim + 1;
                    }
                }

            }
            if (!(breaking))
            {
                ReadingStep3(fileAdress);
            }
        }
        private void ReadingStep3(String fileAdress)
        {
            DataBase = new DataElement(fileAdress, MassivesDataLines);
            StringTable = new Classes.StringTable(fileAdress, NumberOfColumns, MassivesDataLines);
            float valueX, valueY;
            String sline, xline, yline;
            int xCol = comboBoxX.SelectedIndex;
            int yCol = comboBoxY.SelectedIndex;
            string[] substrings;
            for (int i = 0; i < MassivesDataLines; i++)
            {
                sline = DataMassive[i];
                if (sline == "")
                {
                    sline = "";
                    continue;
                }
                substrings = sline.Split(Convert.ToChar(Delimeter));

                if ((xCol + 1) > NumberOfColumns || (yCol + 1) > NumberOfColumns)
                {
                    MessageBox.Show("Указанной колонки не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    breaking = true;
                    goto End;
                }
                xline = substrings[xCol];
                yline = substrings[yCol];
                for (int k = 0; k < NumberOfColumns; k++)
                {
                    StringTable.Cell[k, i] = substrings[k];
                }

                xline = xline.Replace('\0', '.').Replace(".", ",");
                yline = yline.Replace('\0', '.').Replace(".", ",");
                try
                {
                    valueX = Convert.ToSingle(xline);
                    valueY = Convert.ToSingle(yline);
                }
                catch (Exception)
                {
                    String message = "Строчка " + i + " в файле " + LastFileAdress + " не удовлетворяет формату.";
                    MessageBox.Show(message, "Дальнейшее чтение файла не возможно", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    breaking = true;
                    goto End;
                }
                DataBase.Values[i, 0] = valueX;
                DataBase.Values[i, 1] = valueY;

            }
            DataBase.FindMinMax();
        End: ;
        }
        #endregion

        #region Scenarios
        private void MinimizeToInfoWindow()
        {
            splitContainer2.Panel2Collapsed = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            System.Drawing.Rectangle screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            SizeWidth = this.Width;
            SizeHeight = this.Height;
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void MaximizeToWindows()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Height = SizeHeight;
            this.Width = SizeWidth;

        }
        private void OpenFileScenario()
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (treeView1.Nodes.Count == 0)
                {
                    TreeNode treeNode1 = new TreeNode("(Все медианные)");
                    TreeNode treeNode2 = new TreeNode("(Все средние)");
                    TreeNode treeNode = new TreeNode("(Выделить все)", new TreeNode[] {treeNode1, treeNode2});
                    treeNode1.Tag = "allmadian";
                    treeNode2.Tag = "allmiddle";
                    treeNode.Tag = "selectAll";
                    treeView1.Nodes.Add(treeNode);
                }
                Checking = true;
                treeView1.Nodes[0].Checked = false;
                treeView1.Nodes[0].Nodes[0].Checked = false;
                treeView1.Nodes[0].Nodes[1].Checked = false;
                Checking = false;

                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Медианное значение");
                    System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Среднее значение");
                    TreeNode treeNode = new TreeNode(openFileDialog1.FileNames[i], new System.Windows.Forms.TreeNode[] { treeNode1, treeNode2 });
                    ContextMenuStrip Menu = new ContextMenuStrip();

                    ToolStripMenuItem openLabel = new ToolStripMenuItem();
                    openLabel.Text = "в TextReader";
                    openLabel.Tag = openFileDialog1.FileNames[i];
                    openLabel.Click += new EventHandler(ContextMenu_Open);

                    ToolStripMenuItem deleteLabel = new ToolStripMenuItem();
                    deleteLabel.Text = "Удалить";
                    deleteLabel.Tag = openFileDialog1.FileNames[i];
                    deleteLabel.Click += new EventHandler(ContextMenu_Delete);

                    ToolStripMenuItem addAllMedianLabel = new ToolStripMenuItem();
                    addAllMedianLabel.Text = "Выбрать все медианные";
                    addAllMedianLabel.Click += new EventHandler(treeView_addAllMedian);

                    //ToolStripMenuItem removeAllMedianLabel = new ToolStripMenuItem();
                    //removeAllMedianLabel.Text = "Снять все медианные";
                    //removeAllMedianLabel.Click += new EventHandler(treeView_removeAllMedian);

                    ToolStripMenuItem addAllMiddleLabel = new ToolStripMenuItem();
                    addAllMiddleLabel.Text = "Выбрать все средние";
                    addAllMiddleLabel.Click += new EventHandler(treeView_addAllMiddle);

                    //ToolStripMenuItem removeAllMiddleLabel = new ToolStripMenuItem();
                    //removeAllMiddleLabel.Text = "Снять все средние";
                    //removeAllMiddleLabel.Click += new EventHandler(treeView_removeAllMiddle);

                    Menu.Items.AddRange(new ToolStripMenuItem[] { openLabel, addAllMedianLabel, addAllMiddleLabel, deleteLabel });  //, removeAllMedianLabel, removeAllMiddleLabel

                    treeNode.ContextMenuStrip = Menu;
                    treeView1.Nodes.Add(treeNode);
                }
                InitializeComboBoxes();
            }
        }
        private void CreateWordDocument(List<List<String>> dataMedian, List<List<String>> dataMiddle)
        {
            try
            {
                if (dataMedian.Count > 1 || dataMiddle.Count > 1)
                {

                    //Create an instance for word app
                    Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                    //Set animation status for word application
                    winword.ShowAnimation = false;

                    //Set status for word application is to be visible or not.
                    winword.Visible = false;

                    //Create a missing variable for missing value
                    object missing = System.Reflection.Missing.Value;

                    //Create a new document
                    Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                    //Add header into the document
                    foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                    {

                        //Get the header range and add the header details.
                        Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                        headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                        headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                        headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdAuto;
                        headerRange.Font.Size = 10;
                        headerRange.Text = "Таблица создана автоматически программой GraphReader v" + version; ;
                    }

                    //Add the footers into the document
                    foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                    {

                        //Get the footer range and add the footer details.
                        Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                        footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdAuto;
                        footerRange.Font.Size = 10;
                        footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                        footerRange.Text = "Таблица создана автоматически программой GraphReader v" + version;
                    }

                    //adding text to document
                    //document.Content.SetRange(0, 0);
                    //document.Content.Text = "Таблица медианных значений" + Environment.NewLine;




                    if (dataMedian.Count > 1)
                    {
                        //Add paragraph with Heading 1 style
                        Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                        //object styleHeading1 = "Заголовок 1";
                        //para1.Range.set_Style(ref styleHeading1);
                        para1.Range.Text = "Таблица медианных значений";
                        para1.Range.InsertParagraphAfter();

                        //Create a 5X5 table and insert some dummy record
                        Table firstTable = document.Tables.Add(para1.Range, dataMedian.Count, dataMedian[0].Count, ref missing, ref missing);

                        firstTable.Borders.Enable = 1;
                        foreach (Row row in firstTable.Rows)
                        {
                            foreach (Cell cell in row.Cells)
                            {
                                //Header row
                                if (cell.RowIndex == 1)
                                {
                                    cell.Range.Text = dataMedian[0][cell.ColumnIndex - 1];
                                    cell.Range.Font.Bold = 1;
                                    //other format properties goes here
                                    cell.Range.Font.Name = "Times New Roman";
                                    cell.Range.Font.Size = 10;
                                    //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                            
                                    cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                                    //Center alignment for the Header cells
                                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                                }
                                //Data row
                                else
                                {
                                    cell.Range.Text = cell.Range.Text = dataMedian[cell.RowIndex - 1][cell.ColumnIndex - 1];
                                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                    if (cell.ColumnIndex == 1)
                                    {
                                        cell.Range.Font.Size = 8;
                                    }
                                    else
                                    {
                                        cell.Range.Font.Size = 10;
                                    }
                                }
                            }
                        }
                    }

                    if (dataMiddle.Count > 1)
                    {
                        //Add paragraph with Heading 2 style
                        Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                        //object styleHeading2 = "Заголовок 1";
                        //para2.Range.set_Style(ref styleHeading2);
                        para2.Range.Text = Environment.NewLine + "Таблица средних значений";
                        para2.Range.InsertParagraphAfter();

                        //Create a 5X5 table and insert some dummy record
                        Table secondTable = document.Tables.Add(para2.Range, dataMiddle.Count, dataMiddle[0].Count, ref missing, ref missing);

                        secondTable.Borders.Enable = 1;
                        foreach (Row row in secondTable.Rows)
                        {
                            foreach (Cell cell in row.Cells)
                            {
                                //Header row
                                if (cell.RowIndex == 1)
                                {
                                    cell.Range.Text = dataMiddle[0][cell.ColumnIndex - 1];
                                    cell.Range.Font.Bold = 1;
                                    //other format properties goes here
                                    cell.Range.Font.Name = "Times New Roman";
                                    cell.Range.Font.Size = 10;
                                    //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                            
                                    cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                                    //Center alignment for the Header cells
                                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                                }
                                //Data row
                                else
                                {
                                    cell.Range.Text = dataMiddle[cell.RowIndex - 1][cell.ColumnIndex - 1];
                                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                    if (cell.ColumnIndex == 1)
                                    {
                                        cell.Range.Font.Size = 8;
                                    }
                                    else
                                    {
                                        cell.Range.Font.Size = 10;
                                    }
                                }
                            }
                        }
                    }
                    string name = "TableM";

                    //Save the document
                    String writingAdress = textBoxExportPath.Text + "\\" + name + ".docx";

                    int extN = 1;
                    while (File.Exists(writingAdress))
                    {
                        writingAdress = textBoxExportPath.Text + "\\" + name + " (" + extN + ")" + ".docx";
                        extN++;
                    }

                    object filename = writingAdress;
                    document.SaveAs2(ref filename);
                    ((_Document)document).Close(ref missing, ref missing, ref missing);
                    document = null;
                    ((_Application)winword).Quit(ref missing, ref missing, ref missing);
                    winword = null;
                    MessageBox.Show("Создание документа завершено");
                }
                else
                {
                    MessageBox.Show("Не выбрано ни одного среднего или медианного значения");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WaitCursorON()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            tabControl1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            zedGraphControl1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        }
        private void WaitCursorOFF()
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            zedGraphControl1.Cursor = System.Windows.Forms.Cursors.Default;
        }
        private string CallFormat(int dec)
        {
            string fA = "{0:0";
            string fB = "}";

            string format = fA;
            if (dec > 0)
            {
                format += ".";
                for (int q = 0; q < dec; q++)
                {
                    format += "0";
                }
            }
            format += fB;
            return format;
        }
        private bool OnlyPositive(CurveList list)
        {
            bool answer = true;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Points.Count; j++)
                {
                    double var = myPane.CurveList[i].Points[j].Y;
                    if (var < 0)
                    {
                        answer = false;
                    }
                }
            }
            return answer;
        }
        private bool OnlyPositive(float[,] list)
        {
            bool answer = true;
            float vl;
            for (int i = 0; i < MassivesDataLines; i++)
            {
                vl = DataBase.Values[i, 1];

                if (vl < 0)
                {
                    answer = false;
                }
            }
            return answer;
        }
        private void OpenNumbPad()
        {
            if (treeView1.Nodes.Count == 0)
            {
                OpenFileScenario();
            }
            if (treeView1.Nodes.Count != 0)
            {
                NumbPad = new NumbPad(this);
                NumbPad.Show();
                if (!(LastFileIndex == -1))
                {
                    NumbPad.LoadTextBoxInfo();
                }
                NumbPad.TopMost = true;
            }
        }
        private void OpenTableWriter(object sender, EventArgs e)
        {
            TableWriter = new TableWriter(this);
            TableWriter.Show();
            TableWriter.LoadSource();
        }
        #endregion
        
        

    }
}