using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaGUI
{
    public class Model
    {
        Controller controller;
        int k = 0;
        ListManager<String> inner;


         public List<String> result { get; private set; }



        public Model(Controller c)
        {
            this.controller = c;
        }

        public void InsertList(List<String> lst)
        {
            
            this.inner = new ListManager<String>(lst);
        }

        public void SetK(int k)
        {
            this.k = k;
        }

        public void Process()
        {
            var ret = new List<String>();

            //TODO: fix a bug
            var iter = this.inner.Task(k);

            foreach (var i in iter) {
                ret.Add(i);
            };

            this.result = ret;

            controller.setlist(ret);
        }
    }
}
