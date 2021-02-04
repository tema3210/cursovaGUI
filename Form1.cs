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
        public Form1(Controller contr)
        {
            this.controller = contr;
            InitializeComponent();            
        }

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
    }
}
