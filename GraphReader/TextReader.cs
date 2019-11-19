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
    public partial class TextReader : Form
    {
        public String FileName;
        bool filechanged = false;
        bool stopExiting = false;
        int NumberOfLines;
        bool breaking;
        Form3 replaceForm;
        Form4 findForm;        
        
        public TextReader()
        {
            InitializeComponent();
            RefreshPositionLabel();
        }


        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileName = openFileDialog1.FileName;
                OpenScenario(FileName);                
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Вызов функции сохранения с именем файла, 
            //чтобы не появлялся диалог сохранения

            MySaveFile(FileName);
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Вызов функции Saved
            Saved();
            textBoxNotepad.Text = "";
            FileName = "";
            this.Text = "TextReader";
        }
        private void Saved()
        {
            //Если файл был изменен, то выводим вопрос о сохранении файла
            if (filechanged)
            {
                DialogResult res = MessageBox.Show("Сохранить изменения в файле?", "Сохранение файла",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (res == DialogResult.Yes)
                {
                    //При положительном ответе вызываем сохранение
                    MySaveFile(FileName);
                }
                else if (res == DialogResult.Cancel)
                {
                    stopExiting = true;
                }
            }

        }
        private void MySaveFile(String fname)
        {
            //Если переменная с именем файла пустая
            //то вызываем диалог сохранения файла
            
            if (fname == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fname = saveFileDialog1.FileName;
                }
                else
                {
                    goto fEnd;
                }
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(fname))
                {
                    for (int i = 0; i < textBoxNotepad.Lines.Length; i++)
                    {
                        sw.WriteLine(textBoxNotepad.Lines[i]);
                    }                    
                }
                FileName = fname;
                filechanged = false;
            }
            catch
            {
                DialogResult res = MessageBox.Show("Невозможно сохранить файл. Продолжить работу в программе?", "Ошибка",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (res == System.Windows.Forms.DialogResult.No)
                {
                    Close();
                }
            }

        fEnd: ;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySaveFile("");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Saved();//Вопрос о сохранении
            if (!(stopExiting))
            {
                Close();//Выход из приложения  
                stopExiting = false;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Ставим пометку о изменении файла
            if (!filechanged)
            {
                filechanged = true;
            }
            RefreshPositionLabel();
        }

        public void OpenScenario(String fileAdress)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileAdress))
                {                            
                    textBoxNotepad.Text = sr.ReadToEnd();                    
                    sr.Close();
                    RefreshPositionLabel();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка: Невозможно прочитать файл.");
            }

            this.Text = "TextReader - " + fileAdress;       
        }

        private void анализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxNotepad.Text == "")
            {
                MessageBox.Show("TextReader пуст");
            }
            else
            {                
                ReadingStep1();
            }
        }
        public void SelectLine(int k)
        {            
            this.Focus();
            textBoxNotepad.Focus();
            textBoxNotepad.SelectionStart = 0;
            textBoxNotepad.ScrollToCaret();
            int offset = Convert.ToInt32(textBoxNotepad.Size.Height / 19.5 / 2);

            if (k > offset)
            {
                int linescrol = textBoxNotepad.GetFirstCharIndexFromLine(k - offset);
                textBoxNotepad.Select(linescrol, linescrol);
                textBoxNotepad.ScrollToCaret();
            }

            int lineStart = textBoxNotepad.GetFirstCharIndexFromLine(k);
            int lineEnd = textBoxNotepad.Text.IndexOf("\n", lineStart);
            if (lineEnd == -1)
            {
                lineEnd = textBoxNotepad.TextLength;
            }
            textBoxNotepad.Select(lineStart, lineEnd - lineStart);  
        }
        #region Reading
        private void ReadingStep1()
        {                        
            NumberOfLines = textBoxNotepad.Lines.Length;
            progressBar1.Value = 0;            
            progressBar1.Maximum = NumberOfLines;            
            ReadingStep2();
        }
        private void ReadingStep2()
        {
            //
            // Separator Determination
            //            
            breaking = false;

            String sline = textBoxNotepad.Lines[0]; //GetFirstCharIndexFromLine(lineNumber);
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
            progressBar1.PerformStep();


            int NofTabsNew;
            int NofSpacesNew;
            int NofSemiCalNew;
            int NofCommaNew;
            int NofPointsNew;
 
            for (int k = 0; k < NumberOfLines; k++)
            {
                sline = textBoxNotepad.Lines[k];
                if (k == (NumberOfLines - 1))
                {
                    if (sline == "" )
                    {
                        progressBar1.PerformStep();
                        goto End;
                    }
                }
                if ((sline == "" || sline == null ))
                {
                    SelectLine(k);
                    breaking = true;
                    break;
                }
                
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
                    SelectLine(k);
                    breaking = true;
                    break;                       
                }

                if (!(NofSpacesNew == NofSpaces))
                {
                    SelectLine(k);
                    breaking = true;
                    break;   
                }

                if (!(NofSemiCalNew == NofSemiCal))
                {
                    SelectLine(k);
                    breaking = true;
                    break;   
                }

                if (!(NofCommaNew == NofComma))
                {
                    SelectLine(k);
                    breaking = true;
                    break;   
                }
                NofPoints = NofPointsNew + NofPoints;
                progressBar1.PerformStep();
            }

            
            End:
            if (!(breaking))
            {
                MessageBox.Show("Файл прочитан успешно.", "Готово",
                MessageBoxButtons.OK, MessageBoxIcon.Information);          
            }

        }
        #endregion

        private void RefreshPositionLabel()
        {
            int totalline = textBoxNotepad.Lines.Length;
            int caretPos = textBoxNotepad.SelectionStart;
            int lineNumber = textBoxNotepad.GetLineFromCharIndex(caretPos) + 1;
            int colNumber = caretPos - textBoxNotepad.GetFirstCharIndexFromLine(lineNumber - 1);//GetCharacterIndexFromLineIndex(lineNumber - 1);
            string inf = "Стр " + lineNumber + " из " + totalline + ", Кол " + colNumber;
            label1.Text = inf;
        }
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            RefreshPositionLabel();
        }

        private void заменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                replaceForm.Show();
            }
            catch (Exception)
            {
                replaceForm = new Form3(this);
                replaceForm.Show();
            }            
            replaceForm.WindowState = FormWindowState.Normal;
            replaceForm.Activate();
        }

        public void ReplaceFunction(String init, String final)
        {
            string text;
            text = textBoxNotepad.Text.Replace(init, final);
            textBoxNotepad.Text = text;
        }
        public void FindFunction(string searchText)
        {
            int findPos;
            try
            {
                this.Focus();
                textBoxNotepad.Focus();
                findPos = textBoxNotepad.SelectionStart + textBoxNotepad.SelectionLength;
                findPos = textBoxNotepad.Find(searchText, findPos, RichTextBoxFinds.None);
                textBoxNotepad.Select(findPos, searchText.Length);
                findPos += searchText.Length;
            }
            catch
            {
                MessageBox.Show("No Occurences Found");
                findPos = 0;
            }

        }

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                findForm.Show();
            }
            catch (Exception)
            {
                findForm = new Form4(this);
                findForm.Show();
            }
            findForm.WindowState = FormWindowState.Normal;
            findForm.Activate();
        }

        public void MoveTo(int k)
        {
            k = k - 1;
            this.Focus();
            textBoxNotepad.Focus();
            textBoxNotepad.SelectionStart = 0;
            textBoxNotepad.ScrollToCaret();
            int offset = Convert.ToInt32(textBoxNotepad.Size.Height / 19.5 / 2);

            if (k > offset)
            {
                int linescrol = textBoxNotepad.GetFirstCharIndexFromLine(k - offset);
                textBoxNotepad.Select(linescrol, linescrol);
                textBoxNotepad.ScrollToCaret(); 
            }
            
            int lineStart = textBoxNotepad.GetFirstCharIndexFromLine(k);
            int lineEnd = textBoxNotepad.Text.IndexOf("\n", lineStart);
            if (lineEnd == -1)
            {
                lineEnd = textBoxNotepad.TextLength;
            }
            textBoxNotepad.Select(lineStart, lineEnd - lineStart);        
        }

        private void textBoxNotepad_SelectionChanged(object sender, EventArgs e)
        {
            RefreshPositionLabel();
        }

        private void перейтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxNotepad.SelectionStart == textBoxNotepad.TextLength)
            {
                textBoxNotepad.SelectionStart = 0;
                textBoxNotepad.ScrollToCaret();
            }
            else
            {
                textBoxNotepad.SelectionStart = textBoxNotepad.TextLength;
                textBoxNotepad.ScrollToCaret();
            }            
        }
    }
}
