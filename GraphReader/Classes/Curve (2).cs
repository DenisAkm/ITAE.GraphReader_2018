using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphReader.Classes
{
    public class Curve
    {
        public static List<Curve> CurveList = new List<Curve>();
        public double[] X;
        public double[] Y;
        public string Title { get; set; }
        public int Count 
        {
            get 
            {
                return X.Length;
            }
        }
        public string Code;
        ListViewItem ListItem;
        TreeNode Node;

        public Curve(TreeNode _node)
        {

            Title = _node.Text;
            Node = _node;
            Code = Curve.GetUniqCode();

            DataElement2 de = MainForm.Instance.LoadedData.Find(x => x.Name == _node.Parent.Tag);
            int columnY = _node.Index;
            X = de.ReturnColumn(0);
            Y = de.ReturnColumn(columnY);

            string AB = (_node.Text.Split(' '))[1];
            string parentNodeTitle = _node.Parent.Text;
            ListItem = new ListViewItem(String.Concat(parentNodeTitle, "_", AB));
            MainForm.Instance.listViewGraphBrowser.Items.Add(ListItem);
            
            



            CurveList.Add(this);
        }

        public void BuildGraph()
        { 
        
        }
        public static string GetUniqCode()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, 50).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        

    }
}
