using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursovaGUI
{
    public partial class Form1 : Form
    {
        Controller controller;

        #region PublicIface
        public Form1(Controller contr)
        {
            this.controller = contr;
            InitializeComponent();
        }
        public void SetOutList(List<String> data)
        {
            this.OutputListBox.Items.Clear();
            foreach (var i in data)
            {
                this.OutputListBox.Items.Add(i);
            }
        }
        public List<String> GetInput()
        {
            var ret = new List<String>();
            for (int i = 1; i < this.dataGridView1.RowCount; i++)
            {
                ret.Add((String)this.dataGridView1.Rows[i].Cells[0].Value);
            }
            return ret;
        }

        public int GetK()
        {
            return 2;
        }
        #endregion
 
        #region FormCallbacks
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.About();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.Save();
        }

        private void откритьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.Open();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.Manual();
        }

        private void выполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.Action();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.controller.Action();
        }

        #endregion
    }
}
