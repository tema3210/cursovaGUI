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

        public List<String> Process()
        {
            var ret = new List<String>();
            foreach (var i in this.inner.Task(this.k)) {
                ret.Add(i);
            };
            return ret;
        }
    }
}
