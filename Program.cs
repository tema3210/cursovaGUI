﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursovaGUI
{
    public enum Task
    {
        Children,
        Negatives,
        Insertion,
    }
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
            var hello_form = new HelloForm(contr);
            contr.HelloForm = hello_form;

            Application.Run(hello_form);
        }

        public static void stopProgram() => Application.Exit();
        
    }
}
