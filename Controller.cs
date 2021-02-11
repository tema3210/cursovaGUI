using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
        public void Manual()
        {

        }
        public void Save()
        {

        }
        public void Open()
        {

        }
        public void Action()
        {
            //String[] test = new String[1] { "aa" };
            //Form.SetOutList(test);
            var a = Form.GetInput();
            var k = Form.GetK();

            Model.SetK(k);
            Model.InsertList(a);

            var res = Model.Process();
            Form.SetOutList(res);
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
