using GraphReader.Classes;
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

namespace GraphReader
{
    public partial class TableWriter : Form
    {
        List<string> SourceFiles = new List<string>();
        List<float> FrequencyValues = new List<float>();
        List<List<float>> AnswerData = new List<List<float>>();
        MainForm mainForm;
        string format = "";
        bool error = false;
        string[] Delimeter = new string[] { "\t", ",", ".", ";", " " };
        public TableWriter(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxStile.SelectedIndex = 0;
            comboBoxSeparator.SelectedIndex = 0;            
            openFileDialog1.InitialDirectory = mainForm.openFileDialog1.InitialDirectory;
            //textBoxDirectory.Text = mainForm.textBoxExportPath.Text;
            numericUpDownDecPlaces.Value = SettingsForm.DecimalNumber;
        }
        
        

        #region Operators

        private void Format()
        {
            int decplaces = Convert.ToInt32(numericUpDownDecPlaces.Value);
            string fA = "{0:0";
            string fB = "}";

            format = fA;
            if (decplaces > 0)
            {
                format += ".";
                for (int q = 0; q < decplaces; q++)
                {
                    format += "0";
                }
            }
            format += fB;
        }
        private List<String> OpenSource()
        {
            List<String> sourceFileNames = new List<string>();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    sourceFileNames.Add(openFileDialog1.FileNames[i]);
                }
            }
            return sourceFileNames;
        }
        private DataTable CreateTable()
        {
            DataTable table = new DataTable(Path.Combine(SettingsForm.ExportPath, "Таблица промежуточных значений.docx"));

            table.Columns.Add(new DataColumn("Название", System.Type.GetType("System.String")));
            for (int i = 0; i < FrequencyValues.Count; i++)
            {
                string headCell = Convert.ToString(FrequencyValues[i]);
                table.Columns.Add(new DataColumn(headCell, System.Type.GetType("System.String")));
            }
            
            return table;
        }        
        private StringTable Reading(string p)
        {
            mainForm.FileReading(p);
            StringTable st = mainForm.StringTable;
            return st;
        }
        private void AddAnswer(DataTable table, DataElement2 st)
        {   
            double var;
            string vars;
            string fname = Path.GetFileNameWithoutExtension(st.Name);
            int valcol = Convert.ToInt32(numericUpDownColVal.Value) - 1;
            string[] row;
            float[] freqArr = new float[st.RowsCount];
            float[] valArr = new float[st.RowsCount];

            for (int k = 0; k < st.RowsCount; k++)
            {
                try
                {
                    freqArr[k] = Convert.ToSingle(st[0, k].Replace(".", ","));
                    valArr[k] = Convert.ToSingle(st[valcol, k].Replace(".", ","));
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка чтения файла на строчке " + k);
                    error = true;
                    goto EndOfMethod;
                }
            }


            //add line
            row = new string[FrequencyValues.Count + 1];
            row[0] = fname;

            //add marks
            for (int i = 0; i < FrequencyValues.Count; i++)
            {
                //find marks
                int pickIndex = FindElementIndex(freqArr, FrequencyValues[i]);

                var = Math.Round(valArr[pickIndex], Convert.ToInt32(numericUpDownDecPlaces.Value));
                vars = String.Format(format, var);
                if (comboBoxSeparator.SelectedIndex == 1)
                {
                    vars = vars.Replace(",", ".");
                }
                row[i + 1] = vars;
            }
            //
            DataRow datarow = table.NewRow();
            datarow.ItemArray = row;
            table.Rows.Add(datarow);
        EndOfMethod: ;
        }
        
        private int FindElementIndex(float[] arr, float val)
        {            
            float delta = Math.Abs(arr[0] - val);
            int index = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]-val) < delta)
                {
                    delta = Math.Abs(arr[i] - val);
                    index = i; 
                }                
            }

            return index;
        }

        #endregion


        #region Methods and Functions
        
        private void WaitCursor(bool swith)
        {
            if (swith)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                listBoxSource.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                listBoxValue.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            }
            else
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                listBoxSource.Cursor = System.Windows.Forms.Cursors.Default;
                listBoxValue.Cursor = System.Windows.Forms.Cursors.Default;
            }
            
        }       
        public void LoadSource()
        {
            List<String> sourceFileNames = new List<string>();

            for (int i = 0; i < mainForm.treeViewFilesBrowser.Nodes.Count; i++)
            {
                sourceFileNames.Add(mainForm.treeViewFilesBrowser.Nodes[i].Tag.ToString());
            }
            AddSource(sourceFileNames);
        }
        private void AddSource(List<String> sourceFileNames)
        {
            for (int i = 0; i < sourceFileNames.Count; i++)
            {
                SourceFiles.Add(sourceFileNames[i]);
                listBoxSource.Items.Add(Path.GetFileName(sourceFileNames[i]));
            }
        }
        private void SetParameters()
        {
            error = false;
            //SourceFiles.Clear();
            FrequencyValues.Clear();
            AnswerData.Clear();
            
            //for (int i = 0; i < listBoxSource.Items.Count; i++)
            //{                
            //    SourceFiles.Add(listBoxSource.Items[i].ToString());
            //}

            for (int i = 0; i < listBoxValue.Items.Count; i++)
            {
                FrequencyValues.Add(Convert.ToSingle(listBoxValue.Items[i].ToString().Replace(".", ",")));
            }
            Format();
        }       
        
        #endregion

        #region Events

        
        private void button1_Click(object sender, EventArgs e)
        {            
            WaitCursor(true);
            SetParameters();

            DataTable table = CreateTable();

            if (FrequencyValues.Count > 0)
            {
                for (int i = 0; i < SourceFiles.Count && !error; i++)
                {
                    
                    //StringTable st = Reading(SourceFiles[i]);
                    DataElement2 stringDataTable = mainForm.LoadedData.Find(x => x.Name == SourceFiles[i]);
                    AddAnswer(table, stringDataTable);
                }
                if (!error)
                {
                    if (comboBoxStile.SelectedIndex != 0)
                    {
                        table = Transpose(table);
                    }
                    try
                    {
                        mainForm.CreateWordDocument(table);
                        var result = MessageBox.Show("Таблица создана и сохранена как " + Environment.NewLine + table.TableName + ".\r\nХотите продолжить работу в редакторе?", "Информация", MessageBoxButtons.YesNo);
                        if (result == System.Windows.Forms.DialogResult.No)
                        {
                            Close();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка создания таблицы");
                    }   
                }              
            }
            WaitCursor(false);
        }
        private DataTable Transpose(DataTable dt)
        {
            DataTable dtNew = new DataTable(dt.TableName);

            dtNew.Columns.Add(new DataColumn("Название", System.Type.GetType("System.String")));
            
            //adding columns    
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtNew.Columns.Add(new DataColumn(dt.Rows[i].ItemArray[0].ToString(), System.Type.GetType("System.String")));
            }
            

            //Adding Row Data
            for (int k = 1; k < dt.Columns.Count; k++)
            {
                DataRow r = dtNew.NewRow();
                r[0] = dt.Columns[k].ToString();
                for (int j = 1; j <= dt.Rows.Count; j++)
                    r[j] = dt.Rows[j - 1][k];
                dtNew.Rows.Add(r);
            }
            return dtNew;
        }
        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSource(OpenSource());
        }

        private void EnterPressed()
        {
            listBoxValue.Items.Add(textBoxValue.Text);
            textBoxValue.Text = "";
        }
        private void textBoxValue_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == '\r')
            {
                EnterPressed();
            }
            else
            {
                char number = e.KeyChar;

                if (!Char.IsDigit(number) && number != 45 && number != 44 && number != 8) // цифры, минус, клавиша BackSpace
                {
                    e.Handled = true;
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxValue.Items.Clear();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxValue.Items.RemoveAt(listBoxValue.SelectedIndex);
            }
            catch (Exception)
            {       
            }
            
        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SourceFiles.RemoveAt(listBoxSource.SelectedIndex);
                listBoxSource.Items.RemoveAt(listBoxSource.SelectedIndex);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось удалить файл из списка", "Ошибка");
            }
            
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SourceFiles.Clear();
            listBoxSource.Items.Clear();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            int direction = -1;
            // Checking selected item
            if (listBoxSource.SelectedItem == null || listBoxSource.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBoxSource.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBoxSource.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listBoxSource.SelectedItem;
            string selectedSource = SourceFiles[listBoxSource.SelectedIndex];

            // Removing removable element
            SourceFiles.RemoveAt(listBoxSource.SelectedIndex);
            listBoxSource.Items.Remove(selected);
            // Insert it in new position
            SourceFiles.Insert(newIndex, selectedSource);
            listBoxSource.Items.Insert(newIndex, selected);
            // Restore selection
            listBoxSource.SetSelected(newIndex, true);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int direction = 1;
            // Checking selected item
            if (listBoxSource.SelectedItem == null || listBoxSource.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBoxSource.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBoxSource.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listBoxSource.SelectedItem;
            string selectedSource = SourceFiles[listBoxSource.SelectedIndex];
            // Removing removable element
            SourceFiles.RemoveAt(listBoxSource.SelectedIndex);
            listBoxSource.Items.Remove(selected);
            // Insert it in new position
            SourceFiles.Insert(newIndex, selectedSource);
            listBoxSource.Items.Insert(newIndex, selected);
            // Restore selection
            listBoxSource.SetSelected(newIndex, true);
        }

        private void buttonUpVal_Click(object sender, EventArgs e)
        {
            int direction = -1;
            // Checking selected item
            if (listBoxValue.SelectedItem == null || listBoxValue.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBoxValue.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBoxValue.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listBoxValue.SelectedItem;

            // Removing removable element
            listBoxValue.Items.Remove(selected);
            // Insert it in new position
            listBoxValue.Items.Insert(newIndex, selected);
            // Restore selection
            listBoxValue.SetSelected(newIndex, true);
        }

        private void buttonDownVal_Click(object sender, EventArgs e)
        {
            int direction = 1;
            // Checking selected item
            if (listBoxValue.SelectedItem == null || listBoxValue.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBoxValue.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBoxValue.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listBoxValue.SelectedItem;

            // Removing removable element
            listBoxValue.Items.Remove(selected);
            // Insert it in new position
            listBoxValue.Items.Insert(newIndex, selected);
            // Restore selection
            listBoxValue.SetSelected(newIndex, true);
        }                

        private void button2_Click(object sender, EventArgs e)      // Folder Change
        {

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                //textBoxDirectory.Text = folderBrowserDialog1.SelectedPath;                
            }
            
        }
        private void PointPressed(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsLetterOrDigit(number) && number != 95 && number != 8 && number != 32) // цифры и символы, нижнее подчеркивание, клавиша BackSpace
            {
                e.Handled = true;
                MessageBox.Show("Invalid character");
            }

        }



        #endregion

        private void comboBoxSeparator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EnterPressed();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        








    }
}
