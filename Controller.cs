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

        #region Form_Actions
        public void Exit()
        {
            Program.stopProgram();
        }
        public void About()
        {
            System.Windows.Forms.MessageBox.Show("Зробив Бакаев.А.О; гр. 471; КІСІТ КНЕУ", "О программе");
        }
        public void Manual()
        {
            Help.ShowHelp(Form, "file://.\\help.chm");
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
            try
            {
                var a = Form.GetInput();
                var k = Form.GetK();

                Model.SetK(k);
                Model.InsertList(a);

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
