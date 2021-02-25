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
        CyclicListManager<String> inner;

        public List<String> result { get; private set; }

        public Model(Controller c)
        {
            this.controller = c;
        }

        public void InsertList(List<String> lst, Task tsk)
        {
            switch (tsk)
            {
                case Task.Children:
                    var tmp = new ListManagerChild(lst);
                    tmp.k = k;
                    this.inner = tmp;
                    break;
                case Task.Insertion:
                    var tmp2 = new ListManagerInsert(lst);
                    tmp2.el = "INSERTED ELEMENT";
                    this.inner = tmp2;
                    break;
                case Task.Negatives:
                    this.inner = new ListManagerDouble(lst);
                    break;
            }       
        }

        public void SetK(int k)
        {
            this.k = k;
        }

        public void Process()
        {
            var ret = new List<String>();
            var iter = this.inner.Task();

            foreach (var i in iter) {
                ret.Add(i);
            };

            this.result = ret;

            controller.setlist(ret);
        }
    }
}
