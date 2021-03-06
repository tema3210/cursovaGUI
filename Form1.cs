﻿using System;
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
            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                var info = this.dataGridView1.Rows[i].Cells[0].Value;
                if (info != null && (string)info != "")
                {
                    ret.Add((string)info);
                }
            }
            return ret;
        }
        
        public void DisplayInputData(String data)
        {
            var splited = data.Split('\n');
            this.dataGridView1.Rows.Clear();
            foreach(var i in splited)
            {
                if (i != null && i != "")
                    this.dataGridView1.Rows.Add(i);
            }
            
        }

        public void DisplayError(String data)
        {
            this.label2.Visible = true;
            this.label3.Visible = true;

            this.label2.Text = data;
        }

        public int GetK()
        {
            return (int)this.numericUpDown1.Value;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectMode(Task.Children);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectMode(Task.Negatives);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectMode(Task.Insertion);
        }

        public void clearError(object sender, EventArgs e)
        {
            this.label3.Visible = false;
            this.label2.Visible = false;
        }

        #endregion
    }
}
