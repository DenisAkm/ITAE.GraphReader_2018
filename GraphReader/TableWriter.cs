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

namespace GraphReader
{
    public partial class TableWriter : Form
    {
        List<string> SourceFiles = new List<string>();
        List<float> FrequencyValues = new List<float>();
        List<List<float>> AnswerData = new List<List<float>>();
        MainForm mainForm;
        
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
            comboBoxDelimeter.SelectedIndex = 0;
            openFileDialog1.InitialDirectory = mainForm.openFileDialog1.InitialDirectory;
            textBoxDirectory.Text = mainForm.textBoxExportPath.Text;
            numericUpDownDecPlaces.Value = mainForm.numericUpDownDecimalNumb.Value;
        }


        #region Operators and etc.
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
        
        
        #endregion

        #region Methods and Functions
        private void WaitCursorON()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            listBoxSource.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            listBoxValue.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        }
        private void WaitCursorOFF()
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            listBoxSource.Cursor = System.Windows.Forms.Cursors.Default;
            listBoxValue.Cursor = System.Windows.Forms.Cursors.Default;
        }

        public void LoadSource()
        {
            List<String> sourceFileNames = new List<string>();

            for (int i = 1; i < mainForm.treeView1.Nodes.Count; i++)
            {
                sourceFileNames.Add(mainForm.treeView1.Nodes[i].Text);
            }
            AddSource(sourceFileNames);
        }

        private void AddSource(List<String> sourceFileNames)
        {
            for (int i = 0; i < sourceFileNames.Count; i++)
            {
                listBoxSource.Items.Add(sourceFileNames[i]);
            }
        }

        private void SetParameters()
        {
            SourceFiles.Clear();
            FrequencyValues.Clear();
            AnswerData.Clear();
            for (int i = 0; i < listBoxSource.Items.Count; i++)
            {
                SourceFiles.Add(listBoxSource.Items[i].ToString());
            }

            for (int i = 0; i < listBoxValue.Items.Count; i++)
            {
                FrequencyValues.Add(Convert.ToSingle(listBoxValue.Items[i].ToString().Replace(".", ",")));
            }

        }

               
        private void ExtructingFile(string fileName)
        {
            #region SubRegion Reading

            StreamReader sr = new StreamReader(fileName);            
            int numberOfLines = 0;
            int valcol = Convert.ToInt32(numericUpDownColVal.Value) - 1;
            string[] substrings;
            string varline = sr.ReadLine();
            string delimeter = Delimeter[comboBoxDelimeter.SelectedIndex];
            while (varline != null)
            {
                numberOfLines++;                
                varline = sr.ReadLine();
            }

            sr = new StreamReader(fileName);
            float[] freqArr = new float[numberOfLines];
            float[] valArr = new float[numberOfLines];
            try
            {
                for (int i = 0; i < numberOfLines; i++)
                {
                    varline = sr.ReadLine();
                    if (!(varline == ""))
                    {
                        substrings = varline.Split(Convert.ToChar(delimeter));
                        freqArr[i] = Convert.ToSingle(substrings[0].Replace(".", ","));
                        valArr[i] = Convert.ToSingle(substrings[valcol].Replace(".", ","));
                    }
                }
            }
            catch (Exception)
            {
                int errorIndex = AnswerData.Count;
                MessageBox.Show("Unable to read file" + listBoxSource.Items[errorIndex].ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
            
            sr.Close();
            #endregion
                        
            List<float> answerValues = new List<float>(FrequencyValues.Count);
            for (int i = 0; i < FrequencyValues.Count; i++)
            {
                int pickIndex = FindElementIndex(freqArr, FrequencyValues[i]);                
                answerValues.Add(valArr[pickIndex]);
            }
            AnswerData.Add(answerValues);
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
        private void WritteAnswer()
        {
            int decplaces = Convert.ToInt32(numericUpDownDecPlaces.Value);
            string fA = "{0:0";
            string fB = "}";

            string format = fA;
            if (decplaces > 0)
            {
                format += ".";
                for (int q = 0; q < decplaces; q++)
                {
                    format += "0";
                }
            }
            format += fB;

            List<List<string>> table = new List<List<string>>();                       

            double var;
            string vars;
            if (comboBoxStile.SelectedIndex == 0)
            {
                List<string> firstline = new List<string>();
                //First line
                firstline.Add("");
                for (int i = 0; i < listBoxValue.Items.Count; i++)
                {
                    firstline.Add(listBoxValue.Items[i].ToString());
                }
                table.Add(firstline);
                

                //Other lines
                for (int j = 0; j < SourceFiles.Count; j++)
                {
                    List<string> line = new List<string>();
                    string fardess = listBoxSource.Items[j].ToString();
                    line.Add(fardess.Remove(fardess.LastIndexOf(".")).Substring(fardess.LastIndexOf("\\") + 1)); 
                    for (int i = 0; i < FrequencyValues.Count; i++)
                    {   
                        var = Math.Round(AnswerData[j][i], Convert.ToInt32(numericUpDownDecPlaces.Value));
                        vars = String.Format(format, var);
                        if (comboBoxSeparator.SelectedIndex == 1)
                        {
                            vars = vars.Replace(",", ".");
                        }
                        line.Add(vars);
                    }                    
                    table.Add(line);
                    
                }
            }
            else
            {
                List<string> firstline = new List<string>();
                //First line
                firstline.Add("");
                for (int i = 0; i < listBoxSource.Items.Count; i++)
                {
                    string fardess = listBoxSource.Items[i].ToString();
                    firstline.Add(fardess.Remove(fardess.LastIndexOf(".")).Substring(fardess.LastIndexOf("\\") + 1));
                }
                table.Add(firstline);

                //Other lines
                for (int j = 0; j < FrequencyValues.Count; j++)
                {
                    List<string> line = new List<string>();
                    line.Add(listBoxValue.Items[j].ToString());                     
                    for (int i = 0; i < SourceFiles.Count; i++)
                    {
                        var = Math.Round(AnswerData[i][j], Convert.ToInt32(numericUpDownDecPlaces.Value));
                        vars = String.Format(format, var);
                        if (comboBoxSeparator.SelectedIndex == 1)
                        {
                            vars = vars.Replace(",", ".");
                        }
                        line.Add(vars);
                    }
                    table.Add(line);                    
                }
            }
            CreateWordDocument(table);
        }
        private void SaveParameters()
        {
        }

        private void CreateWordDocument(List<List<String>> tableData)
        {            
            try
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
                    headerRange.Text = "Таблица создана автоматически программой GraphReader " + MainForm.version; ;
                }

                //Add the footers into the document
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                {

                    //Get the footer range and add the footer details.
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdAuto;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    footerRange.Text = "Таблица создана автоматически программой GraphReader " + MainForm.version;
                }

                //Add paragraph with Heading 1 style
                Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);

                para1.Range.Text = "Таблица промежуточных значений";
                para1.Range.InsertParagraphAfter();


                if (tableData.Count > 1)
                {
                    //Create a 5X5 table and insert some dummy record
                    Table firstTable = document.Tables.Add(para1.Range, tableData.Count, tableData[0].Count, ref missing, ref missing);

                    firstTable.Borders.Enable = 1;
                    foreach (Row row in firstTable.Rows)
                    {
                        foreach (Cell cell in row.Cells)
                        {
                            //Header row
                            if (cell.RowIndex == 1)
                            {
                                cell.Range.Text = tableData[0][cell.ColumnIndex - 1];
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
                                cell.Range.Text = cell.Range.Text = tableData[cell.RowIndex - 1][cell.ColumnIndex - 1];
                                cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                if (cell.ColumnIndex == 1)
                                {
                                    cell.Range.Font.Size = 10;
                                }
                                else
                                {
                                    cell.Range.Font.Size = 10;
                                }
                            }
                        }
                    }
                }

                //Save the document
                String writingAdress = textBoxDirectory.Text + "\\" + textBoxTableName.Text + ".docx";

                int extN = 1;
                while (File.Exists(writingAdress))
                {
                    writingAdress = textBoxDirectory.Text + "\\" + textBoxTableName.Text + " (" + extN + ")" + ".docx";
                    extN++;
                }                
                object filename = writingAdress;
                document.SaveAs2(ref filename);
                ((_Document)document).Close(ref missing, ref missing, ref missing);
                document = null;
                ((_Application)winword).Quit(ref missing, ref missing, ref missing);
                winword = null;
                string mesagetext = "Расположение документа: " + Environment.NewLine + writingAdress + Environment.NewLine + "Закрыть TableWriter?";
                string caption = "Создание документа завершено";
                DialogResult result;
                result = MessageBox.Show(this, mesagetext, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    this.Close();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events
        private void button1_Click(object sender, EventArgs e)
        {
            WaitCursorON();
            SetParameters();            
            if (FrequencyValues.Count > 0)
            {
                for (int i = 0; i < SourceFiles.Count; i++)
                {
                    ExtructingFile(SourceFiles[i]);
                }
                WritteAnswer();                
            }
            WaitCursorOFF();
        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSource(OpenSource());
        }

        private void textBoxValue_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == '\r')
            {
                listBoxValue.Items.Add(textBoxValue.Text);
                textBoxValue.Text = "";
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
                listBoxSource.Items.RemoveAt(listBoxSource.SelectedIndex);
            }
            catch (Exception)
            {                                
            }
            
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

            // Removing removable element
            listBoxSource.Items.Remove(selected);
            // Insert it in new position
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

            // Removing removable element
            listBoxSource.Items.Remove(selected);
            // Insert it in new position
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
                textBoxDirectory.Text = folderBrowserDialog1.SelectedPath;                
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

        








    }
}
