using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursovaGUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var contr = new Controller();
            var model = new Model(contr);
            contr.Model = model;
            var form = new Form1(contr);
            contr.Form = form;
            Application.Run(form);
        }

        public static void stopProgram() => Application.Exit();
        
    }
}
