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
    public partial class HelloForm : Form
    {
        Controller controller;
        public HelloForm(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.run();
        }
    }
}
