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
    public partial class FindWindow : Form
    {
        TextReader FatherForm;
        public FindWindow(TextReader ff)
        {
            InitializeComponent();
            FatherForm = ff;
            this.Location = new Point(ff.Location.X + 200, ff.Location.Y + 100);
        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            FatherForm.FindFunction(textBox1.Text);
        }

        private void buttonGoTo_Click(object sender, EventArgs e)
        {
            int line;
            try
            {
                line = Convert.ToInt32(textBox2.Text);
                FatherForm.MoveTo(line);
            }
            catch (Exception)
            {
                                
            }
            
        }


    }
}
