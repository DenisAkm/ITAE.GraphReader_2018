using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphReader
{
    public partial class Form3 : Form
    {
        TextReader FatherForm;
        string backUp;
        public Form3(TextReader ff)
        {
            InitializeComponent();
            FatherForm = ff;                            //FatherForm = (Form2)Owner; работает после сборки     
            this.Location = new Point(ff.Location.X + 200, ff.Location.Y + 100);
            backUp = FatherForm.textBoxNotepad.Text;
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            FatherForm.ReplaceFunction(textBox1.Text, textBox2.Text);
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            FatherForm.textBoxNotepad.Text = backUp;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
