using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphReader
{
    public partial class SettingsForm : Form
    {
        public static int DelimeterIndex = -1;
        public static bool HeaderDetectionEnable = true;
        public static string DecimalDelimeter = "Точка";
        public static int DecimalNumber = 2;
        public static double Start = 0;
        public static double Finish = 180;
        public static double Step = 15;

        public static string ExportPath = Environment.CurrentDirectory.ToString();
        

        public SettingsForm()
        {
            InitializeComponent();
            SetCurrentSettings();
        }

        private void SetCurrentSettings()
        {            
            if (DelimeterIndex == -1)
	        {
                checkBoxDelimeter.Checked = true;
            }
            else
            {
                checkBoxDelimeter.Checked = false;
                comboBoxDelimeter.SelectedIndex = DelimeterIndex;
            }            

            checkBoxHeader.Checked = HeaderDetectionEnable;
            comboBoxDecimalDelimeter.SelectedIndex = comboBoxDecimalDelimeter.FindString(DecimalDelimeter);
            numericUpDownDecimalNumb.Value = DecimalNumber;

            textBoxStart.Text = Start.ToString();
            textBoxFinish.Text = Finish.ToString();
            textBoxStep.Text = Step.ToString();

            textBoxExportPath.Text = ExportPath;
            //показывать конец пути
            textBoxExportPath.SelectionStart = textBoxExportPath.Text.Length;
            textBoxExportPath.SelectionLength = 0;
        }
        private void SaveCurrentSettings()
        {
            if (checkBoxDelimeter.Checked)
            {
                DelimeterIndex = -1;
            }
            else
            {                
                DelimeterIndex = comboBoxDelimeter.SelectedIndex;
            }

            HeaderDetectionEnable = checkBoxHeader.Checked;
            DecimalDelimeter = comboBoxDecimalDelimeter.SelectedItem.ToString();
            DecimalNumber = Convert.ToInt32(numericUpDownDecimalNumb.Value);

            Start = Convert.ToDouble(textBoxStart.Text);
            Finish = Convert.ToDouble(textBoxFinish.Text);
            Step = Convert.ToDouble(textBoxStep.Text);

            ExportPath = textBoxExportPath.Text;
        }

        private void checkBoxDelimeter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDelimeter.Checked)
            {
                comboBoxDelimeter.Enabled = false;                
                comboBoxDelimeter.SelectedIndex = -1;
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

        private void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHeader.Checked)
            {
                HeaderDetectionEnable = true;
            }
            else
            {
                HeaderDetectionEnable = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveCurrentSettings();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonExportPathBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxExportPath.Text = folderBrowserDialog1.SelectedPath;
                //показывать конец пути
                textBoxExportPath.SelectionStart = textBoxExportPath.Text.Length;
                textBoxExportPath.SelectionLength = 0;
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
    }
}
