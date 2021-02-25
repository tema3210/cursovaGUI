using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursovaGUI
{
    public class Controller
    {
        public Model Model { private get; set; }
        public Form1 Form { private get; set; }

        public Task? mode = null;

        #region Form_Actions
        public void Exit()
        {
            Program.stopProgram();
        }
        public void About()
        {
            MessageBox.Show("Зробив Бакаев.А.О; гр. 471; КІСІТ КНЕУ", "Про програму");
        }
        public void Manual()
        {
            if (System.IO.File.Exists(@".\Manual.chm"))
            {
                Help.ShowHelp(Form, @".\Manual.chm");
            }
            
        }
        public void Save()
        {
            var data = Model.result;

            using (SaveFileDialog openFileDialog = new SaveFileDialog())
            {
                openFileDialog.InitialDirectory = ".";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {   
                        if (data != null)
                        {
                            foreach (var i in data)
                            {
                                if (i != null && i!= "")
                                {
                                    writer.WriteLine(i.Trim());   
                                }
                            }
                        }
                        
                    }
                }
            }

        }
        public void Open()
        {
            var fileContent = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            Form.DisplayInputData(fileContent);
        }
        public void Action()
        {
            if (this.mode is Task tsk)
            {
                try
                {
                    var a = Form.GetInput();
                    var k = Form.GetK();

                    //this have to be done first
                    Model.SetK(k);
                    // before this
                    Model.InsertList(a, tsk);

                    Model.Process();
                }
                catch (ArgumentException ex) when (ex.Message == "empty list")
                {
                    //TODO: Process (do nothing)
                }
                catch (ArgumentException ex) when (ex.Message == "empty val")
                {
                    //TODO: Process impossible case
                }
                catch (ArgumentException ex) when (ex.Message == "Negatives non-number")
                {
                    //TODO: Show error
                }
            } else
            {
                //TODO: Show error
            }
            
        }

        public void SelectMode(Task mode)
        {
            this.mode = mode;
        }
        #endregion

        #region Model_actions
        public void setlist(List<String> args)
        {
            Form.SetOutList(args);
        }
        #endregion
    }
}
