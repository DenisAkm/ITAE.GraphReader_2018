using GraphReader.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;
using ZedGraph;

namespace GraphReader
{
    public partial class MainForm : Form
    {
        #region Singleton Pattern
        private static MainForm instance = null;
        public static MainForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainForm(new string[0]);
                }
                return instance;
            }
        }
        #endregion
        //use
        RadioButton[] radioSet;
        public List<DataElement2> LoadedData = new List<DataElement2>();
        public const string version = "2.0";
        public string date = "04.09.19";
        private string LastFileSelected = "";
        //

        //undefined        
        private TextReader TextReader;
        private TableWriter TableWriter;
        private NumbPad NumbPad;
        public Info GraphInfo = new Info();
        public bool breaking;
        private int lastAddedValue = 0;
        private DateTime lastLoading;
        private int firstVisibleRow;
        private ScrollBars gridScrollBars;

        private GraphPane myPane = new GraphPane();
        private int LastFileIndex = -1;

        
        private bool Checking = false;
        float Start;
        float Finish;
        float Step;
        bool Loading = false;
        TextBox[] TextBoxRange = new TextBox[3];
        System.Windows.Forms.CheckBox[] CheckBoxRange = new System.Windows.Forms.CheckBox[3];
        int SizeHeight;
        int SizeWidth;
        public bool listViewGraphBrowserItemChecked_trigger = true;
        public bool radioButtonModifierChanged_trigger = true;

        int ScrollRange = 500;
        


        //old
        public DataElement DataBase;
        public StringTable StringTable = new StringTable();
        private String LastFileAdress = "";
        public int NumberOfColumns;


        

        #region ProgramInitialization
        public MainForm(string[] files)
        {
            InitializeComponent();
            InitializeDataGrid();
            InitializeGraph();
            //InitializeTreeViewMenu();            

            //treeViewGraphBrowser.Nodes.Clear();
            //TextBoxRange[0] = textBoxStart;
            //TextBoxRange[1] = textBoxFinish;
            //TextBoxRange[2] = textBoxStep;

            //CheckBoxRange[0] = checkBoxAutoStart;
            //CheckBoxRange[1] = checkBoxAutoFinish;
            //CheckBoxRange[2] = checkBoxAutoStep;

            
            

            if (files.Length != 0)
            {
                LoadFileScenario(files);    
            }
            radioSet = new RadioButton[] { radioButtonOriginal, radioButtonMedian, radioButtonMiddle };
            instance = this;
        }                
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += version;
        }
        private void InitializeTreeViewMenu()
        {
            //ContextMenuStrip menu = new ContextMenuStrip();

            //ToolStripMenuItem expandLabel = new ToolStripMenuItem();
            //expandLabel.Text = "Развернуть";
            //expandLabel.Click += new EventHandler(treeView_Expand);

            //ToolStripMenuItem collapseLabel = new ToolStripMenuItem();
            //collapseLabel.Text = "Cвернуть";
            //collapseLabel.Click += new EventHandler(treeView_Collapse);

            //ToolStripMenuItem addLabel = new ToolStripMenuItem();
            //addLabel.Text = "Добавить";
            //addLabel.Click += new EventHandler(treeView_Add);

            //ToolStripMenuItem clearLabel = new ToolStripMenuItem();
            //clearLabel.Text = "Очистить";
            //clearLabel.Click += new EventHandler(treeView_Clear);

            //menu.Items.AddRange(new ToolStripMenuItem[] { addLabel, expandLabel, collapseLabel, clearLabel });
            //treeViewGraphBrowser.ContextMenuStrip = menu;
        }
        private void InitializeDataGrid()
        {
            //load firs 100 rows
            LoadRows(null);

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
            //if (!Loading)
            //{
            //    Loading = true;
            //    if (comboBoxX.SelectedIndex == -1)
            //    {
            //        comboBoxX.SelectedIndex = 0;
            //    }
            //    if (comboBoxY.SelectedIndex == -1)
            //    {
            //        comboBoxY.SelectedIndex = 1;
            //    }
            //    Loading = false;    
            //}
            
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

            int deleteIndex = treeViewFilesBrowser.SelectedNode.Index;
            treeViewFilesBrowser.Nodes.RemoveAt(deleteIndex);
            //if (node.Checked)
            //{
            //    GraphRemove(deleteFileName);
            //}
            //if (node.Nodes[0].Checked)
            //{
            //    RemoveMedianGraph(deleteFileName.Remove(deleteFileName.IndexOf(".")) + "_median");
            //}
            //if (node.Nodes[1].Checked)
            //{
            //    RemoveMiddleGraph(deleteFileName.Remove(deleteFileName.IndexOf(".")) + "_middle");
            //}
            LastFileIndex = -1;
            LastFileAdress = "";
            LoadEmptyRows();

            treeViewFilesBrowser.SelectedNode = null;
        }
        private void ContextMenu_Expand(object sender, EventArgs e)
        {
            treeViewFilesBrowser.ExpandAll();
        }
        private void ContextMenu_Collapse(object sender, EventArgs e)
        {
            treeViewFilesBrowser.CollapseAll();
        }

        private void treeViewFilesBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LastFileSelected = GetParentFullName(treeViewFilesBrowser.SelectedNode);
            ShowData(LoadedData.Find(x => x.Name == LastFileSelected));
        }
        private void treeViewFilesBrowser_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = (sender as TreeView).SelectedNode;
            if (node != null)
            {
                if (node.Parent != null)
                {
                    var _curve = new Curve(node);
                    _curve.ShowGraph(GetActiveRadioButtonModifier(), checkBox_dB.Checked, checkBox1.Checked, checkBoxNorma.Checked);                    
                }
            }
        }
        private void listViewGraphBrowser_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listViewGraphBrowserItemChecked_trigger)
            {
                ListViewItem item = e.Item;
                Curve c = Curve.CurveList.Find(x => x.ListItem.GetHashCode() == item.GetHashCode());
                if (item.Checked)
                {
                    c.ShowGraph(GetActiveRadioButtonModifier(), checkBox_dB.Checked, checkBox1.Checked, checkBoxNorma.Checked);                                        
                }
                else
                {
                    c.HideGraph();                    
                }                
            }            
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = listViewGraphBrowser.SelectedItems;
            int count = items.Count;
            for (int i = 0; i < count; i++)
            {
                Curve c = Curve.CurveList.Find(x => x.ListItem.GetHashCode() == items[0].GetHashCode());
                Curve.Delete(c);
            }
        }
        private void переименоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = listViewGraphBrowser.SelectedItems;
            if (items.Count != 0)
            {
                ListViewItem item = items[0];
                item.BeginEdit();
            }           

        }

        private void CurveModificationChanged(object sender, EventArgs e)
        {
            if (radioButtonModifierChanged_trigger)
            {
                RadioButton rb = sender as RadioButton;
                if (rb.Checked)
                {
                    var items = listViewGraphBrowser.SelectedItems;
                    int count = items.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Curve c = Curve.CurveList.Find(x => x.ListItem.GetHashCode() == items[i].GetHashCode());
                        c.HideGraph();
                        c.ShowGraph(GetActiveRadioButtonModifier(), checkBox_dB.Checked, checkBox1.Checked, checkBoxNorma.Checked);
                    }
                }
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }


        private void listViewGraphBrowser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var items = listViewGraphBrowser.SelectedItems;
            if (items.Count > 0)
            {
                Curve c = Curve.CurveList.Find(x => x.ListItem.GetHashCode() == items[0].GetHashCode());
                SetActiveRadioButton(c.currentModifier);
                SetCheckedBoxes(c.CheckedTodB, c.CheckedToTimes, c.CheckedToNorma);
            }            
        }

        private void SetCheckedBoxes(bool _checkedTodB, bool _checkedToTimes, bool _checkedToNorma )
        {
            checkBox_dB.Checked = _checkedTodB;
            checkBox1.Checked = _checkedToTimes;
            checkBoxNorma.Checked = _checkedToNorma;
        }
        #endregion

        #region StripMenuPanel
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileScenario();
            ClearAll();
        }

        private void ClearAll()
        {            
            if (MessageBox.Show("Очистить всё?","Внимание",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                treeViewFilesBrowser.Nodes.Clear();
                LoadedData = new List<DataElement2>();
                LoadEmptyRows();
                listViewGraphBrowser.Clear();
                Curve.Clear();    
            }            
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

            //if (выбратьВсеГрафикиToolStripMenuItem.Checked)
            //{
            //    if (treeViewGraphBrowser.Nodes.Count != 0)
            //    {
            //        treeViewGraphBrowser.Nodes[0].Checked = true;
            //    }
            //    else
            //    {
            //        выбратьВсеГрафикиToolStripMenuItem.Checked = false;
            //    }
            //}
            //else
            //{
            //    if (treeViewGraphBrowser.Nodes.Count != 0)
            //    {
            //        treeViewGraphBrowser.Nodes[0].Checked = false;
            //    }
            //}
            
        }

        private void выбратьВсеМедианныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (выбратьВсеМедианныеToolStripMenuItem.Checked)
            //{
            //    if (treeViewGraphBrowser.Nodes.Count != 0)
            //    {
            //        treeViewGraphBrowser.Nodes[0].Nodes[0].Checked = true;
            //    }
            //    else
            //    {
            //        выбратьВсеМедианныеToolStripMenuItem.Checked = false;
            //    }
            //}
            //else
            //{
            //    if (treeViewGraphBrowser.Nodes.Count != 0)
            //    {
            //        treeViewGraphBrowser.Nodes[0].Nodes[0].Checked = false;
            //    }       
            //}
            
        }

        private void выбратьВсеСредниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (выбратьВсеСредниеToolStripMenuItem.Checked)
            //{
            //    if (treeViewGraphBrowser.Nodes.Count != 0)
            //    {
            //        treeViewGraphBrowser.Nodes[0].Nodes[1].Checked = true;
            //    }
            //    else
            //    {
            //        выбратьВсеСредниеToolStripMenuItem.Checked = false;
            //    }
            //}
            //else
            //{
            //    if (treeViewGraphBrowser.Nodes.Count != 0)
            //    {
            //        treeViewGraphBrowser.Nodes[0].Nodes[1].Checked = false;
            //    }
            //}
            
        }
        
        private void открытьTableWriterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewGraphBrowser.SelectedItems.Count != 0)
            {
                TableWriter = new TableWriter(this);
                TableWriter.Show();    
            }
            else
            {
                MessageBox.Show("Выделите хотя бы один график", "Внимание");
            }
        }

        private void преобразоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNumbPad();
        }

        private void текстовыйРедакторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextReader = new TextReader();
            TextReader.Show();
            if (treeViewFilesBrowser.SelectedNode != null)
            {
                TextReader.FileName = treeViewFilesBrowser.SelectedNode.Tag.ToString();
                TextReader.OpenScenario(treeViewFilesBrowser.SelectedNode.Tag.ToString());
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Программа GraphReader v" + version + " предназначена для визуализации табличных данных, а также их последующей обработки и редактирования \n\nПрограмма позволяет выгружать результаты обработки в виде *.docx и *.txt файлов: \n\t- средних значений \n\t- медианных значений \n\t- контрольных значений \n\nДата сборки текущей версии " + date + "";
            MessageBox.Show(message, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void свернутьРазвернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (treeViewGraphBrowser.Nodes.Count > 0)
            //{
            //    if (свернутьРазвернутьToolStripMenuItem.Checked == true)
            //    {
            //        treeViewGraphBrowser.ExpandAll();
            //    }
            //    else
            //    {
            //        treeViewGraphBrowser.CollapseAll();
            //    }
            //}
            //else
            //{
            //    свернутьРазвернутьToolStripMenuItem.Checked = false;
            //}
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
        public void FirstLoadRows(DataElement2 data)
        {
            firstVisibleRow = 0;
            lastAddedValue = 0;
            ScrollRange = 500;
            dataGridView1.Rows.Clear();
            LoadRows(data);
        }
        private void LoadRows(DataElement2 data)
        {
            int dataLines = 0;
            if (data != null)
            {
                dataLines = data.RowsCount;
            }
            if (!(lastAddedValue == dataLines) || dataLines == 0)
            {
                HideScrollBars();                
                lastLoading = DateTime.Now;

                //create rows
                if (dataLines > 0 && !(breaking))
                {
                    if (lastAddedValue + ScrollRange <= dataLines)
                    {
                        for (int i = lastAddedValue; i < ScrollRange + lastAddedValue; i++)
                        {
                            dataGridView1.Rows.Add();
                            for (int j = 0; j < data.ColumnsCount; j++)
                            {
                                dataGridView1[j, i].Value = data[j, i];
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
                            for (int j = 0; j < data.ColumnsCount; j++)
                            {
                                dataGridView1[j, i].Value = data[j, i];
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

                        //LoadRows(LoadedData.Find(x => x.Name == GetParentFullName(treeViewFilesBrowser.SelectedNode)));
                    }
                    else
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = e.OldValue;
                    }
                }
            }
        }
        string GetParentFullName(TreeNode node)
        {
            string fileName = "";
            if (node.Parent == null)
            {
                fileName = node.Tag.ToString();
            }
            else
            {
                fileName = node.Parent.Tag.ToString();
            }
            return fileName;
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
                String fileAdress = listViewGraphBrowser.Items[showFileNumber].Tag.ToString();                
                FileReading(fileAdress);
                //FirstLoadRows();

                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            }
        }
        void ShowData(DataElement2 data)
        {
            FirstLoadRows(data);

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            
        }
        private void GetDataBase()
        {
            //float valueX, valueY;
            //String xline, yline;
            
            //int xCol = comboBoxX.SelectedIndex;
            //int yCol = comboBoxY.SelectedIndex;
                                    
           
            //if ((xCol + 1) > StringTable.ColomnsCount || (yCol + 1) > StringTable.ColomnsCount)
            //{
            //    MessageBox.Show("Указанной колонки не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    breaking = true;
            //}
            //else
            //{
            //    for (int j = 0; j < StringTable.RowsCount; j++)
            //    {
            //        try
            //        {
            //            xline = StringTable.Cell[xCol, j];
            //            yline = StringTable.Cell[yCol, j];

            //            xline = xline.Replace('\0', '.').Replace(".", ",");
            //            yline = yline.Replace('\0', '.').Replace(".", ",");
            //            valueX = Convert.ToSingle(xline);
            //            valueY = Convert.ToSingle(yline);
            //        }
            //        catch (Exception)
            //        {
            //            String message = "Строчка " + j + " в файле " + LastFileAdress + " не удовлетворяет формату.";
            //            MessageBox.Show(message, "Дальнейшее чтение файла не возможно", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            breaking = true;
            //            break;
            //        }
            //    }                
            //}
            //if (!breaking)
            //{
            //    DataBase = new DataElement(StringTable, xCol, yCol);
            //    DataBase.FindMinMax();
            //}
            
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!(listViewGraphBrowser.Items.Count == 0))
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
            //Loading = true;
            //int colx = comboBoxX.SelectedIndex;
            //int coly = comboBoxY.SelectedIndex;
            //if (GraphInfo.Exist(LastFileAdress))
            //{
            //    int n = GraphInfo.Number(LastFileAdress);
            //    colx = GraphInfo.GetX(n);
            //    coly = GraphInfo.GetY(n);
            //}
            
            //textBoxFileName.Text = Path.GetFileName(LastFileAdress);

            //object[] alfa = new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S" };
            //comboBoxX.Items.Clear();
            //comboBoxY.Items.Clear();

            //for (int i = 0; i < NumberOfColumns; i++)
            //{
            //    comboBoxX.Items.Add(alfa[i]);
            //    comboBoxY.Items.Add(alfa[i]);
            //}
            //if (NumberOfColumns != 0)
            //{
            //    if (colx > NumberOfColumns)
            //    {
            //        comboBoxX.SelectedIndex = 0;    
            //    }
            //    else
            //    {
            //        comboBoxX.SelectedIndex = colx;
            //    }
            //    if (coly > NumberOfColumns)
            //    {
            //        comboBoxY.SelectedIndex = 1;    
            //    }
            //    else
            //    {
            //        comboBoxY.SelectedIndex = coly;
            //    }                
            //}

            //AutoRangePanelInfo();

            //Loading = false;
        }
        private void AutoRangePanelInfo()
        {
            Loading = true;
            if (DataBase != null)
            {
                //if (checkBoxAutoStart.Checked)
                //{
                //    textBoxStart.Text = Convert.ToString(DataBase.Begin);
                //    Start = DataBase.Begin;

                //}
                //if (checkBoxAutoFinish.Checked)
                //{

                //    textBoxFinish.Text = Convert.ToString(DataBase.End);
                //    Finish = DataBase.End;

                //}
                //if (checkBoxAutoStep.Checked)
                //{
                //    Step = (float)((DataBase.End - DataBase.Begin) / 10);
                //    textBoxStep.Text = Convert.ToString(Step);
                //}
            }
            Loading = false;
        }
        
        
       
        private void checkBoxModification_CheckedChanged(object sender, EventArgs e)
        {
            if (!(breaking))
            {
                var items = listViewGraphBrowser.SelectedItems;
                int count = items.Count;
                for (int i = 0; i < count; i++)
                {
                    Curve c = Curve.CurveList.Find(x => x.ListItem.GetHashCode() == items[i].GetHashCode());
                    c.HideGraph();
                    c.ShowGraph(c.currentModifier, checkBox_dB.Checked, checkBox1.Checked, checkBoxNorma.Checked);
                }
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
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
       
        
        
        private void ColumnXChanged(object sender, EventArgs e)
        {
            //RefreshGraph();
        }
        private int CountSelectedNonInitialCurves()
        {
            //int number = 0;
            //for (int i = 0; i < treeViewGraphBrowser.Nodes.Count; i++)
            //{
            //    if (treeViewGraphBrowser.Nodes[i].Nodes[0].Checked == true)
            //    {
            //        number++;
            //    }
            //    if (treeViewGraphBrowser.Nodes[i].Nodes[1].Checked == true)
            //    {
            //        number++;
            //    }
            //}
            //return number;
            return listViewGraphBrowser.CheckedItems.Count;
        }

        
        private void RefreshGraph()
        {
            //if (!Loading)
            //{
            //    Loading = true;
            //    for (int i = 0; i < treeViewGraphBrowser.Nodes.Count; i++)
            //    {
            //        if (treeViewGraphBrowser.Nodes[i].Text == LastFileAdress)
            //        {
            //            if (treeViewGraphBrowser.Nodes[i].Checked)
            //            {
            //                treeViewGraphBrowser.Nodes[i].Checked = false;
            //                treeViewGraphBrowser.Nodes[i].Checked = true;
            //                if (treeViewGraphBrowser.Nodes[i].Nodes[0].Checked)
            //                {
            //                    treeViewGraphBrowser.Nodes[i].Nodes[0].Checked = false;
            //                    treeViewGraphBrowser.Nodes[i].Nodes[0].Checked = true;
            //                }
            //                if (treeViewGraphBrowser.Nodes[i].Nodes[1].Checked)
            //                {
            //                    treeViewGraphBrowser.Nodes[i].Nodes[1].Checked = false;
            //                    treeViewGraphBrowser.Nodes[i].Nodes[1].Checked = true;
            //                }
            //            }
            //        }
            //    }
            //    Loading = false;
            //}
        }

        #endregion

        #region GraphControl
        private void DrawSheelds()
        {
            //if (!(DataBase.Values.Length == -1))
            //{
            //    if (!(myPane.CurveList.IndexOf("LeftGate") == -1) && !(myPane.CurveList.IndexOf("RightGate") == -1))
            //    {
            //        myPane.CurveList.RemoveAt(myPane.CurveList.IndexOf("LeftGate"));
            //        myPane.CurveList.RemoveAt(myPane.CurveList.IndexOf("RightGate"));
            //    }
            //}



            //PointPairList listLeft = new PointPairList();
            //PointPairList listRight = new PointPairList();

            //if (!(checkBox_dB.Checked))
            //{
            //    listLeft.Add(Start, GraphInfo.Min);
            //    listLeft.Add(Start, GraphInfo.Max);

            //    listRight.Add(Finish, GraphInfo.Min);
            //    listRight.Add(Finish, GraphInfo.Max);
            //}
            //else
            //{
            //    listLeft.Add(Start, 20 * Math.Log10(GraphInfo.Min));
            //    listLeft.Add(Start, 20 * Math.Log10(GraphInfo.Max));

            //    listRight.Add(Finish, 20 * Math.Log10(GraphInfo.Min));
            //    listRight.Add(Finish, 20 * Math.Log10(GraphInfo.Max));
            //}
                                   
            //LineItem Left_curve = myPane.AddCurve("LeftGate", listLeft, Color.Red, SymbolType.None);
            //LineItem Right_curve = myPane.AddCurve("RightGate", listRight, Color.Red, SymbolType.None);


            //Left_curve.Line.Width = 1F;
            //Left_curve.Symbol.Size = 2F;
            //Left_curve.Tag = "Border";


            //Right_curve.Line.Width = 1F;
            //Right_curve.Symbol.Size = 2F;
            //Right_curve.Tag = "Border";


            //if (checkBoxBorders.Checked)
            //{
            //    myPane.CurveList[myPane.CurveList.IndexOf("RightGate")].IsVisible = true;
            //    myPane.CurveList[myPane.CurveList.IndexOf("LeftGate")].IsVisible = true;
            //}
            //else
            //{
            //    myPane.CurveList[myPane.CurveList.IndexOf("RightGate")].IsVisible = false;
            //    myPane.CurveList[myPane.CurveList.IndexOf("LeftGate")].IsVisible = false;
            //}

            //zedGraphControl1.AxisChange();
            //zedGraphControl1.Invalidate();
        }

        public LineItem GraphAddCurve(string code, double[] X, double[] Y)
        {
            String filename = code;
            PointPairList list = new PointPairList();
            for (int i = 0; i < X.Length; i++)
            {
                list.Add(X[i], Y[i]);
            }

            Random r = new Random();
            LineItem f1_curve = myPane.AddCurve(filename, list, Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)), SymbolType.None);
            f1_curve.Line.Width = 2F;
            f1_curve.Symbol.Size = 2F;
            //f1_curve.Tag = "";

            //GraphInfo.Add(DataBase);
            //DrawSheelds();

            myPane.XAxis.Scale.MinAuto = true;
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            return f1_curve;
        }

        public void GraphRemoveCurve(Curve c)
        {
            myPane.CurveList.RemoveAt(myPane.CurveList.IndexOf(c.Code));            

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
          
        }
        private void GraphAdd()
        {
            String filename = DataBase.Title;
            if (!(GraphInfo.Exist(filename)))
            {
                PointPairList list = new PointPairList();
                for (int i = 0; i < DataBase.Rows; i++)
                {
                    list.Add(DataBase.Values[i, 0], DataBase.Values[i, 1]);
                }
                Random r = new Random();
                LineItem f1_curve = myPane.AddCurve(DataBase.Title, list, Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)), SymbolType.None);
                f1_curve.Line.Width = 2F;
                f1_curve.Symbol.Size = 2F;
                f1_curve.Tag = "Origin";

                GraphInfo.Add(DataBase);
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
                        for (int i = 0; i < DataBase.Rows; i++)
                        {
                            list.Add(DataBase.Values[i, 0], 20 * Math.Log10(DataBase.Values[i, 1]));
                        }
                        Random r = new Random();
                        Random g = new Random();
                        LineItem f1_curve = myPane.AddCurve(filename, list, Color.FromArgb(r.Next(120), r.Next(256), r.Next(256)), SymbolType.None);
                        f1_curve.Line.Width = 2F;
                        f1_curve.Symbol.Size = 2F;
                        f1_curve.Tag = "Origin";

                        GraphInfo.Add(DataBase);
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

                LineItem f1_curve = myPane.AddCurve(filename, list, Color.FromArgb(r.Next(256), r.Next(120), r.Next(256)), SymbolType.None);
                f1_curve.Line.Width = 3F;
                f1_curve.Symbol.Size = 2F;
                f1_curve.Tag = "Middle";
                GraphInfo.Add(filename, DataBase.xColumn, DataBase.yColumn, DataBase.Min, DataBase.Max);
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

                    LineItem f1_curve = myPane.AddCurve(filename, list, Color.FromArgb(r.Next(256), r.Next(120), r.Next(256)), SymbolType.None);
                    f1_curve.Line.Width = 3F;
                    f1_curve.Symbol.Size = 2F;
                    f1_curve.Tag = "Middle";
                    GraphInfo.Add(filename, DataBase.xColumn, DataBase.yColumn, Convert.ToSingle(20 * Math.Log10(DataBase.MiddleMin)), Convert.ToSingle(20 * Math.Log10(DataBase.MiddleMax)));
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
                
                LineItem f1_curve = myPane.AddCurve(filename, list, Color.FromArgb(r.Next(256), r.Next(120), r.Next(256)), SymbolType.None);
                f1_curve.Line.Width = 3F;
                f1_curve.Symbol.Size = 2F;
                f1_curve.Tag = "Median";
                GraphInfo.Add(filename, DataBase.xColumn, DataBase.yColumn, DataBase.Min, DataBase.Max);
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

                    LineItem f1_curve = myPane.AddCurve(filename, list, Color.FromArgb(r.Next(256), r.Next(120), r.Next(256)), SymbolType.None);
                    f1_curve.Line.Width = 3F;
                    f1_curve.Symbol.Size = 2F;
                    f1_curve.Tag = "Median";
                    GraphInfo.Add(filename, DataBase.xColumn, DataBase.yColumn, Convert.ToSingle(20 * Math.Log10(DataBase.MedianMin)), Convert.ToSingle(20 * Math.Log10(DataBase.MedianMax)));
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
        public string[,] FileReading(String fileadress)
        {            
            List<string> dataMassive = GetStringMassive(fileadress);
            string[,] cells = null;
            if (dataMassive.Count > 0)
            {
                string separator = "";
                if (SettingsForm.DelimeterIndex == -1)
                {
                    separator = GetSeparator(dataMassive);
                }
                else
                {
                    string[] setDelimeter = { "\t", " ", ".", ",", ";" };
                    separator = setDelimeter[SettingsForm.DelimeterIndex];
                }
                int skiplines = DetectSkipLines(dataMassive, separator);
                cells = GetCells(dataMassive, separator, skiplines);
            }
            else
            {
                breaking = true;
            }
            return cells;
        }
        
        private List<String> GetStringMassive(String fileAdress)
        {
            StreamReader sr = new StreamReader(fileAdress);
            int numberOfLines = 0;
            string varline = sr.ReadLine();
            while (varline != null)
            {
                if (!(varline == ""))
                {
                    numberOfLines++;
                }
                varline = sr.ReadLine();
            }
            List<string> stringMassive = new List<string>(numberOfLines);

            sr = new StreamReader(fileAdress);
            for (int i = 0; i < numberOfLines; i++)
            {
                stringMassive.Add(sr.ReadLine());
            }
            sr.Close();

            return stringMassive;            
        }
        private string GetSeparator(List<string> stringMassive)
        {
            //
            // Separator Determination
            //            
            breaking = false;
            bool keepgoing = true;
            string Delimeter = "";

            //if (checkBoxDelimeter.Checked)
            //{
            int skiplimit = stringMassive.Count / 10;
            for (int skipline = 0; skipline < skiplimit && keepgoing; skipline++)
            {
                String sline = stringMassive[skipline];

                int NofTabs = GetNumberOf(sline, "\t");
                int NofSpaces = GetNumberOf(sline, " ");
                int NofSemiCal = GetNumberOf(sline, ";");
                int NofComma = GetNumberOf(sline, ",");
                int NofPoints = GetNumberOf(sline, ".");


                int NofTabsNew;
                int NofSpacesNew;
                int NofSemiCalNew;
                int NofCommaNew;
                int NofPointsNew;
                int NumOfDelim = 0;

                for (int k = skipline + 1; k < stringMassive.Count; k++)
                {
                    sline = stringMassive[k];
                    NofTabsNew = GetNumberOf(sline, "\t");
                    NofSpacesNew = GetNumberOf(sline, " ");
                    NofSemiCalNew = GetNumberOf(sline, ";");
                    NofPointsNew = GetNumberOf(sline, ",");
                    NofCommaNew = GetNumberOf(sline, ".");


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
                        break;
                    }
                    else
                    {
                        if (k == stringMassive.Count - 1)
                        {
                            keepgoing = false;
                        }
                    }
                }
            }
            if (keepgoing)
            {
                MessageBox.Show("Не обнаружен разделитель столбцов. Попробуйте ввести разделитель столбцов вручную.", "Невозможно прочитать файл",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop);
                breaking = true;
            }
            //}
            //// следующая часть кода к удалению часть кода к удалению
            //else
            //{
            //    string[] setDelimeter = { "\t", " ", ".", ",", ";" };
            //    Delimeter = setDelimeter[comboBoxDelimeter.SelectedIndex];
            //    String vline = stringMassive[0];
            //    String sline = vline;

            //    int NumOfDelim = 0;
            //    if (Delimeter == "")
            //    {
            //        NumberOfColumns = 1;
            //    }
            //    else
            //    {
            //        while (!(vline.IndexOf(Delimeter) == -1))
            //        {
            //            vline = vline.Substring(vline.IndexOf(Delimeter) + 1);
            //            NumOfDelim++;
            //        }

            //        if (sline.Substring(sline.LastIndexOf(Delimeter) + 1) == "")
            //        {
            //            NumberOfColumns = NumOfDelim;
            //        }
            //        else
            //        {
            //            NumberOfColumns = NumOfDelim + 1;
            //        }
            //    }

            //}
            return Delimeter;

        }

        private int GetColumnNumber(List<string> stringMassive, string separator)
        {
            string sline = stringMassive[stringMassive.Count - 1];
            int colNumber = GetNumberOf(sline, separator);

            if (sline.Substring(sline.LastIndexOf(separator) + 1) != "")
            {
                colNumber++;
            }
            
            return colNumber;
        }
        private int DetectSkipLines(List<string> stringMassive, string separator)
        {
            string line = "";
            bool keepgoing = true;
            int skiplines = 0;
            int numberOfColumns = GetNumberOf(stringMassive[stringMassive.Count - 1], separator);

            for (int i = stringMassive.Count - 1; i >= 0 && keepgoing; i--)
            {
                line = stringMassive[i];
                string[] arr = line.Split(Convert.ToChar(separator));
                for (int m = 0; m < numberOfColumns; m++)
                {
                    string cell = arr[m];
                    try
                    {
                        float var = Convert.ToSingle(cell.Replace(".", ","));
                    }
                    catch (Exception)
                    {
                        keepgoing = false;
                        skiplines = i + 1;
                        break;
                    }
                }
            }
            return skiplines;
        }
        private string[,] GetCells(List<string> stringMassive, string separator, int skipline)
        {
            int columnNumber = GetColumnNumber(stringMassive, separator);

            string[,] cells = new string[columnNumber, stringMassive.Count - skipline];
            string sline;
            string[] substrings;
            for (int i = skipline; i < stringMassive.Count; i++)
            {
                sline = stringMassive[i];

                substrings = sline.Split(Convert.ToChar(separator));

                for (int k = 0; k < columnNumber; k++)
                {
                    cells[k, i - skipline] = substrings[k];
                }
            }
            return cells;
        }

        
        
        private int GetNumberOf(string line, string sep)
        {
            int NofSep = 0;
            String vline = line;
            while (!(vline.IndexOf(sep) == -1))
            {
                vline = vline.Substring(vline.IndexOf(sep) + 1);
                NofSep++;
            }
            return NofSep;
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
            //openFileDialog1.FileName = "";
            //if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    if (treeViewGraphBrowser.Nodes.Count == 0)
            //    {
            //        TreeNode treeNode1 = new TreeNode("(Все медианные)");
            //        TreeNode treeNode2 = new TreeNode("(Все средние)");
            //        TreeNode treeNode = new TreeNode("(Выделить все)", new TreeNode[] {treeNode1, treeNode2});
            //        treeNode1.Tag = "allmadian";
            //        treeNode2.Tag = "allmiddle";
            //        treeNode.Tag = "selectAll";
            //        treeViewGraphBrowser.Nodes.Add(treeNode);
            //    }
            //    Checking = true;
            //    treeViewGraphBrowser.Nodes[0].Checked = false;
            //    treeViewGraphBrowser.Nodes[0].Nodes[0].Checked = false;
            //    treeViewGraphBrowser.Nodes[0].Nodes[1].Checked = false;
            //    Checking = false;

            //    for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
            //    {
            //        System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Медианное значение");
            //        System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Среднее значение");
            //        TreeNode treeNode = new TreeNode(openFileDialog1.FileNames[i], new System.Windows.Forms.TreeNode[] { treeNode1, treeNode2 });
            //        ContextMenuStrip Menu = new ContextMenuStrip();

            //        ToolStripMenuItem openLabel = new ToolStripMenuItem();
            //        openLabel.Text = "в TextReader";
            //        openLabel.Tag = openFileDialog1.FileNames[i];
            //        openLabel.Click += new EventHandler(ContextMenu_Open);

            //        ToolStripMenuItem deleteLabel = new ToolStripMenuItem();
            //        deleteLabel.Text = "Удалить";
            //        deleteLabel.Tag = openFileDialog1.FileNames[i];
            //        deleteLabel.Click += new EventHandler(ContextMenu_Delete);

            //        ToolStripMenuItem addAllMedianLabel = new ToolStripMenuItem();
            //        addAllMedianLabel.Text = "Выбрать все медианные";
            //        addAllMedianLabel.Click += new EventHandler(treeView_addAllMedian);                    

            //        ToolStripMenuItem addAllMiddleLabel = new ToolStripMenuItem();
            //        addAllMiddleLabel.Text = "Выбрать все средние";
            //        addAllMiddleLabel.Click += new EventHandler(treeView_addAllMiddle);                    

            //        Menu.Items.AddRange(new ToolStripMenuItem[] { openLabel, addAllMedianLabel, addAllMiddleLabel, deleteLabel });  //, removeAllMedianLabel, removeAllMiddleLabel

            //        treeNode.ContextMenuStrip = Menu;
            //        treeViewGraphBrowser.Nodes.Add(treeNode);
            //    }
                //InitializeComboBoxes();
            //}
        }
        private void OpenFileScenario(string[] Files)
        {
            //if (treeViewGraphBrowser.Nodes.Count == 0)
            //{
            //    TreeNode treeNode1 = new TreeNode("(Все медианные)");
            //    TreeNode treeNode2 = new TreeNode("(Все средние)");
            //    TreeNode treeNode = new TreeNode("(Выделить все)", new TreeNode[] { treeNode1, treeNode2 });
            //    treeNode1.Tag = "allmadian";
            //    treeNode2.Tag = "allmiddle";
            //    treeNode.Tag = "selectAll";
            //    treeViewGraphBrowser.Nodes.Add(treeNode);
            //}
            //Checking = true;
            //treeViewGraphBrowser.Nodes[0].Checked = false;
            //treeViewGraphBrowser.Nodes[0].Nodes[0].Checked = false;
            //treeViewGraphBrowser.Nodes[0].Nodes[1].Checked = false;
            //Checking = false;

            //for (int i = 0; i < Files.Length; i++)
            //{
            //    System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Медианное значение");
            //    System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Среднее значение");
            //    TreeNode treeNode = new TreeNode(Files[i], new System.Windows.Forms.TreeNode[] { treeNode1, treeNode2 });
            //    ContextMenuStrip Menu = new ContextMenuStrip();

            //    ToolStripMenuItem openLabel = new ToolStripMenuItem();
            //    openLabel.Text = "в TextReader";
            //    openLabel.Tag = Files[i];
            //    openLabel.Click += new EventHandler(ContextMenu_Open);

            //    ToolStripMenuItem deleteLabel = new ToolStripMenuItem();
            //    deleteLabel.Text = "Удалить";
            //    deleteLabel.Tag = Files[i];
            //    deleteLabel.Click += new EventHandler(ContextMenu_Delete);

            //    ToolStripMenuItem addAllMedianLabel = new ToolStripMenuItem();
            //    addAllMedianLabel.Text = "Выбрать все медианные";
            //    addAllMedianLabel.Click += new EventHandler(treeView_addAllMedian);

            //    //ToolStripMenuItem removeAllMedianLabel = new ToolStripMenuItem();
            //    //removeAllMedianLabel.Text = "Снять все медианные";
            //    //removeAllMedianLabel.Click += new EventHandler(treeView_removeAllMedian);

            //    ToolStripMenuItem addAllMiddleLabel = new ToolStripMenuItem();
            //    addAllMiddleLabel.Text = "Выбрать все средние";
            //    addAllMiddleLabel.Click += new EventHandler(treeView_addAllMiddle);

            //    //ToolStripMenuItem removeAllMiddleLabel = new ToolStripMenuItem();
            //    //removeAllMiddleLabel.Text = "Снять все средние";
            //    //removeAllMiddleLabel.Click += new EventHandler(treeView_removeAllMiddle);

            //    Menu.Items.AddRange(new ToolStripMenuItem[] { openLabel, addAllMedianLabel, addAllMiddleLabel, deleteLabel });  //, removeAllMedianLabel, removeAllMiddleLabel

            //    treeNode.ContextMenuStrip = Menu;
            //    treeViewGraphBrowser.Nodes.Add(treeNode);
            //}
        }

        void LoadFileScenario()
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    if (!IsFileLoaded(openFileDialog1.FileNames[i]))
                    {
                        string[,] cells = FileReading(openFileDialog1.FileNames[i]);

                        if (cells != null)
                        {
                            LoadedData.Add(new DataElement2(openFileDialog1.FileNames[i], cells));

                            TreeNode[] nodes = GenerateNodes(LoadedData[LoadedData.Count - 1].ColumnsCount - 1);
                            TreeNode treeNode = new TreeNode(Path.GetFileNameWithoutExtension(openFileDialog1.FileNames[i]), nodes);
                            treeNode.Tag = openFileDialog1.FileNames[i];
                            ContextMenuStrip Menu = new ContextMenuStrip();

                            ToolStripMenuItem expandLabel = new ToolStripMenuItem();
                            expandLabel.Text = "Развернуть";
                            expandLabel.Tag = openFileDialog1.FileNames[i];
                            expandLabel.Click += new EventHandler(ContextMenu_Expand);
                            
                            ToolStripMenuItem collapseLabel = new ToolStripMenuItem();
                            collapseLabel.Text = "Свернуть";
                            collapseLabel.Tag = openFileDialog1.FileNames[i];
                            collapseLabel.Click += new EventHandler(ContextMenu_Collapse);

                            ToolStripMenuItem openLabel = new ToolStripMenuItem();
                            openLabel.Text = "в TextReader";
                            openLabel.Tag = openFileDialog1.FileNames[i];
                            openLabel.Click += new EventHandler(ContextMenu_Open);

                            ToolStripMenuItem deleteLabel = new ToolStripMenuItem();
                            deleteLabel.Text = "Удалить";
                            deleteLabel.Tag = openFileDialog1.FileNames[i];
                            deleteLabel.Click += new EventHandler(ContextMenu_Delete);

                            Menu.Items.AddRange(new ToolStripMenuItem[] { expandLabel, collapseLabel, openLabel, deleteLabel });

                            treeNode.ContextMenuStrip = Menu;
                            treeViewFilesBrowser.Nodes.Add(treeNode);
                        }
                    }
                }                
            }
        }

        private TreeNode[] GenerateNodes(int p)
        {            
            TreeNode[] nodes =  new TreeNode[p];
            if (p > 4)
            {
                p = 4;
            }
            string[] alphbet = new string[] { "B", "C", "D", "E", "F" };
            for (int i = 0; i < p; i++)
            {
                nodes[i] = new TreeNode(String.Concat("Посторить A-", alphbet[i]));             
            }
            return nodes;
        }

        private bool IsFileLoaded(string p)
        {
            bool ans = false;
            for (int i = 0; i < LoadedData.Count; i++)
            {
                if (LoadedData[i].Name == p)
                {
                    ans = true;
                    break;
                }
            }
            return ans;
        }

        void LoadFileScenario(string[] Files)
        {
            treeViewFilesBrowser.BeginUpdate();
            for (int i = 0; i < Files.Length; i++)
            {
                if (IsFileLoaded(Files[i]))
                {
                    string[,] cells = FileReading(Files[i]);

                    if (cells != null)
                    {
                        LoadedData.Add(new DataElement2(Files[i], cells));

                        TreeNode[] nodes = GenerateNodes(LoadedData[LoadedData.Count - 1].ColumnsCount - 1);
                        TreeNode treeNode = new TreeNode(Path.GetFileNameWithoutExtension(Files[i]), nodes);
                        treeNode.Tag = Files[i];
                        ContextMenuStrip Menu = new ContextMenuStrip();

                        ToolStripMenuItem openLabel = new ToolStripMenuItem();
                        openLabel.Text = "в TextReader";
                        openLabel.Tag = Files[i];
                        openLabel.Click += new EventHandler(ContextMenu_Open);

                        ToolStripMenuItem deleteLabel = new ToolStripMenuItem();
                        deleteLabel.Text = "Удалить";
                        deleteLabel.Tag = Files[i];
                        deleteLabel.Click += new EventHandler(ContextMenu_Delete);

                        Menu.Items.AddRange(new ToolStripMenuItem[] { openLabel, deleteLabel });

                        treeNode.ContextMenuStrip = Menu;
                        treeViewFilesBrowser.Nodes.Add(treeNode);                       
                    }
                }
            }
            treeViewFilesBrowser.EndUpdate();
        }
        public void CreateWordDocument(DataTable datatable)
        {
            if (datatable.Rows.Count > 0)
            {                
                string adress = datatable.TableName;
                DocX document = DocX.Create(adress);
                string headlineText = Path.GetFileNameWithoutExtension(datatable.TableName);

                var headLineFormat = new Formatting();
                headLineFormat.FontFamily = new Xceed.Words.NET.Font("Times New Roman");
                headLineFormat.Size = 18D;
                headLineFormat.Position = 12;

                document.InsertParagraph(headlineText, false, headLineFormat);

                // Add a Table to this document.
                Table t = document.AddTable(datatable.Rows.Count + 1, datatable.Columns.Count);
                // Specify some properties for this Table.
                t.Alignment = Alignment.center;
                //t.Design = TableDesign.MediumGrid1Accent2;
                
                // Add content to this Table.
                for (int c = 0; c < datatable.Columns.Count; c++)
                {
                    t.Rows[0].Cells[c].Paragraphs.First().Append(datatable.Columns[c].ColumnName);
                    for (int l = 0; l < datatable.Rows.Count; l++)
                    {
                        t.Rows[l + 1].Cells[c].Paragraphs.First().Append(datatable.Rows[l].ItemArray.ElementAt(c).ToString());
                    }
                }
                document.PageLayout.Orientation = Xceed.Words.NET.Orientation.Landscape;
                // Insert the Table into the document.
                document.InsertTable(t);                
                document.Save();                
            }          
        }

        private void WaitCursorON()
        {            
            tableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            zedGraphControl1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            splitContainer1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            dataGridView1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        }
        private void WaitCursorOFF()
        {            
            tableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            zedGraphControl1.Cursor = System.Windows.Forms.Cursors.Default;
            splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Cursor = System.Windows.Forms.Cursors.Default;
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
            for (int i = 0; i < DataBase.Rows; i++)
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
            if (treeViewFilesBrowser.Nodes.Count == 0)
            {
                LoadFileScenario();
            }
            if (treeViewFilesBrowser.Nodes.Count != 0)
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
            
        }

        private void AddGraphScenario(string p, int index)
        {
            
        }
        #endregion


        

        public RadioButton GetActiveRadioButtonModifier()
        {   
            for (int i = 0; i < radioSet.Length; i++)
            {
                if (radioSet[i].Checked)
                {
                    return radioSet[i];
                }
            }
            return null;
        }

        public void SetActiveRadioButton(RadioButton rb)
        {
            for (int i = 0; i < radioSet.Length; i++)
            {
                if (radioSet[i].GetHashCode() == rb.GetHashCode())
                {
                    radioButtonModifierChanged_trigger = false;
                    radioSet[i].Checked = true;
                    radioButtonModifierChanged_trigger = true;
                }
            }            
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var formsettings = new SettingsForm();
            formsettings.Show();
        }

        private void таблицаМедианныхсреднихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewGraphBrowser.CheckedItems.Count != 0)
            {
                int countLines = GetLineByGraphBrowerIndex(0).Points.Count;
                if (ControlLinesNumber(countLines))
                {

                    string format = CallFormat(SettingsForm.DecimalNumber);
                    string dirName = Path.Combine(SettingsForm.ExportPath, "Results_" + DateTime.Today.ToString("ddMMyy"));
                    if (!Directory.Exists(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    // Create a new DataTable.
                    string medTableadress = Path.Combine(dirName, "Таблица медианных значений" + ".docx");
                    string midTableadress = Path.Combine(dirName, "Таблица средних значений" + ".docx");

                    System.Data.DataTable mediantable = new DataTable(medTableadress);
                    System.Data.DataTable middletable = new DataTable(midTableadress);


                    mediantable.Columns.Add(new DataColumn("Название", System.Type.GetType("System.String")));
                    middletable.Columns.Add(new DataColumn("Название", System.Type.GetType("System.String")));
                    //mediantable.PrimaryKey = new DataColumn[] { firstColumn };


                    for (int i = 0; i < listViewGraphBrowser.CheckedItems.Count; i++ )
                    {
                        LineItem item = GetLineByGraphBrowerIndex(i);
                        Curve c = Curve.CurveList.Find(x => x.ListItem.GetHashCode() == listViewGraphBrowser.CheckedItems[i].GetHashCode());
                        if (c.currentModifier.Text == "Среднеарифметическое" || c.currentModifier.Text == "Медианное")
                        {
                            for (int n = 1; n < item.Points.Count; n = n + 2)
                            {
                                string firststr = item.Points[n - 1].X.ToString();
                                string secondstr = item.Points[n].X.ToString();
                                //DataColumn column = new DataColumn(firststr + "..." + secondstr, System.Type.GetType("System.String"));

                                mediantable.Columns.Add(new DataColumn(firststr + "..." + secondstr, System.Type.GetType("System.String")));
                                middletable.Columns.Add(new DataColumn(firststr + "..." + secondstr, System.Type.GetType("System.String")));
                            }
                            break;
                        }
                    }

                    for (int i = 0; i < listViewGraphBrowser.CheckedItems.Count; i++)
                    {
                        LineItem item = GetLineByGraphBrowerIndex(i);
                        Curve c = Curve.CurveList.Find(x => x.ListItem.GetHashCode() == listViewGraphBrowser.CheckedItems[i].GetHashCode());

                        if (c.currentModifier.Text == "Среднеарифметическое" || c.currentModifier.Text == "Медианное")
                        {
                            string name = Path.GetFileName(listViewGraphBrowser.CheckedItems[i].Text.ToString());
                            name = name.Remove(name.LastIndexOf("_"));
                            string[] row = new string[item.Points.Count / 2 + 1];
                            row[0] = name;
                            int counter = 1;
                            for (int j = 0; j < item.Points.Count; j = j + 2)
                            {
                                Decimal val = Convert.ToDecimal(item.Points[j].Y);
                                val = Math.Round(val, SettingsForm.DecimalNumber);
                                row[counter] = String.Format(format, val);
                                counter++;
                            }

                            if (c.currentModifier.Text == "Медианное")
                            {
                                DataRow datarow = mediantable.NewRow();
                                datarow.ItemArray = row;
                                mediantable.Rows.Add(datarow);
                            }
                            if (c.currentModifier.Text == "Среднеарифметическое")
                            {
                                DataRow datarow = middletable.NewRow();
                                datarow.ItemArray = row;
                                middletable.Rows.Add(datarow);
                            }
                        }
                    }

                    if (mediantable.Rows.Count > 0 || middletable.Rows.Count > 0)
                    {
                        DialogResult result = System.Windows.Forms.DialogResult.Yes;
                        if (File.Exists(medTableadress) || File.Exists(midTableadress))
                        {
                            result = MessageBox.Show("Файл с таким названием уже существует, заменить его?", "Предупреждение", MessageBoxButtons.YesNo);                            
                        }
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            WaitCursorON();
                            string textinfo = "Готово. Файлы сохранёны как" + Environment.NewLine;
                            if (mediantable.Rows.Count > 0)
                            {
                                CreateWordDocument(mediantable);
                                textinfo += medTableadress + Environment.NewLine;
                            }
                            if (middletable.Rows.Count > 0)
                            {
                                CreateWordDocument(middletable);
                                textinfo += midTableadress + Environment.NewLine;
                            }
                            WaitCursorOFF();
                            MessageBox.Show(textinfo, "Информация", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ни одно медианное или среднее значение не построено", "Внимание", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Не все выделенные графики имеют одинаковое число точек", "Внимание", MessageBoxButtons.OK);
                }            
            }
            else
            {
                MessageBox.Show("Ни одно медианное или среднее значение не выбрано", "Внимание", MessageBoxButtons.OK);
            }
        }

        private void таблицаКонтрольныхЗначенийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewFilesBrowser.Nodes.Count != 0)
            {
                TableWriter = new TableWriter(this);
                TableWriter.Show();
                TableWriter.LoadSource();
            }
            else
            {
                MessageBox.Show("Выберите хотя бы один график", "Внимание");
            }
        }

        private void выгрузитьВtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CountSelectedNonInitialCurves() != 0)
            {
                string format = CallFormat(SettingsForm.DecimalNumber);
                String exportPath;
                exportPath = SettingsForm.ExportPath;
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
                            yVal = Math.Round(yVal, SettingsForm.DecimalNumber);
                            string line = myPane.CurveList[i].Points[j].X.ToString() + "\t" + String.Format(format, yVal);
                            if (SettingsForm.DecimalDelimeter == "Точка")
                            {
                                line = line.Replace(",", ".");
                            }
                            sw.WriteLine(line);
                        }
                        sw.Close();
                    }
                }
                MessageBox.Show("Файлы созданы и сохранены в папке " + Environment.NewLine + exportPath, "Информация", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ни одно медианное или среднее значение не выбрано", "Внимание", MessageBoxButtons.OK);
            }
        }

       
        private void загрузитьtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFileScenario();
        }

        private void поФайлуНаГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String exportPath = SettingsForm.ExportPath;
            string format = CallFormat(SettingsForm.DecimalNumber);
            for (int i = 0; i < listViewGraphBrowser.Items.Count; i++)
            {
                ListViewItem item = listViewGraphBrowser.Items[i];
                if (listViewGraphBrowser.Items[i].Checked)
                {
                    Curve c = Curve.CurveList.Find(x => x.ListItem.GetHashCode() == item.GetHashCode());
                    LineItem pointList = c.LineOnGraph;

                    String partName = item.Text;
                    String postfix = "";
                    if (c.currentModifier.Text == "Медианное")
                    {
                        postfix = "_m";
                    }
                    if (c.currentModifier.Text == "Среднеарифметическое")
                    {
                        postfix = "_s";
                    }
                    string dirName = Path.Combine(exportPath, "Results_" + DateTime.Today.ToString("ddMMyy"));
                    if (!Directory.Exists(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    StreamWriter sw = new StreamWriter(Path.Combine(dirName, partName + postfix + ".dat"));


                    for (int j = 0; j < pointList.Points.Count; j++)
                    {
                        Decimal yVal = Convert.ToDecimal(pointList.Points[j].Y);
                        yVal = Math.Round(yVal, SettingsForm.DecimalNumber);
                        string line = pointList.Points[j].X.ToString() + "\t" + String.Format(format, yVal);
                        if (SettingsForm.DecimalDelimeter == "Точка")
                        {
                            line = line.Replace(",", ".");
                        }
                        sw.WriteLine(line);
                    }

                    sw.Close();
                }
            }
        }

        private void всеВОдинФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string totalText = "\t";
            string format = CallFormat(SettingsForm.DecimalNumber);
            string dirName = Path.Combine(SettingsForm.ExportPath, "Results_" + DateTime.Today.ToString("ddMMyy"));
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            int k = 1;
            string filename = Path.Combine(dirName, "res_1.dat");

            while (File.Exists(filename))
            {
                k++;
                filename = Path.Combine(dirName, "res_" + k + ".dat");
            }

            for (int i = 0; i < listViewGraphBrowser.CheckedItems.Count; i++)
            {
                totalText += listViewGraphBrowser.CheckedItems[i].Text + "\t";
            }
            totalText += "\r\n";

            int countLines = GetLineByGraphBrowerIndex(0).Points.Count;

            if (ControlLinesNumber(countLines))
            {
                for (int j = 0; j < countLines; j++)
                {
                    for (int i = 0; i < listViewGraphBrowser.CheckedItems.Count; i++)
                    {
                        LineItem pointList = GetLineByGraphBrowerIndex(i);
                        if (i == 0)
                        {
                            totalText += pointList.Points[j].X.ToString() + "\t";
                        }

                        double yVal = Math.Round(pointList.Points[j].Y, SettingsForm.DecimalNumber);

                        totalText += String.Format(format, yVal) + "\t";
                    }
                    totalText += "\r\n";
                }

                if (SettingsForm.DecimalDelimeter == "Точка")
                {
                    totalText = totalText.Replace(",", ".");
                }
                StreamWriter sw = new StreamWriter(filename);
                sw.Write(totalText);
                sw.Close();
            }
            else
            {
                MessageBox.Show("Не все выделенные графики имеют одинаковое число точек");
            }
        }

        private bool ControlLinesNumber(int controlSum)
        {
            bool answer = true;            
            for (int i = 0; i < listViewGraphBrowser.CheckedItems.Count; i++)
            {
                if (GetLineByGraphBrowerIndex(i).Points.Count != controlSum)
                {
                    answer = false;
                }
            }
            return answer;
        }

        private LineItem GetLineByGraphBrowerIndex(int p)
        {
            var item = listViewGraphBrowser.CheckedItems[p];
            Curve c = Curve.CurveList.Find(x => x.ListItem.GetHashCode() == item.GetHashCode());
            return c.LineOnGraph;
        }        

        private void listViewGraphBrowser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                удалитьToolStripMenuItem_Click(sender, null);
            }
        }

        

       
        

       

        

        
        

        

        

        
        
    }
}