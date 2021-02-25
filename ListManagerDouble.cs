using System;
using System.Collections.Generic;

namespace CursovaGUI
{
    //There is a bug
    class ListManagerDouble : ListManager<String>
    {
        public ListManagerDouble(List<String> arg): base(arg) { }

        public override IEnumerable<String> Task()
        {
            //init iter
            var curr = this.inner;

            do
            {
                double c = 0.0;
                string data = curr.Data.Trim();
                if (Double.TryParse(data,out c))
                {
                    if (c > 0)
                    {
                        var t = curr.Next;
                        yield return curr.Consume();
                        curr = t;
                    } else
                    {
                        var t = curr.Next;
                        curr.Consume();
                        curr = t;
                    };
                } else
                {
                    throw new ArgumentException("Negatives non-number");
                };
            } while (curr.Prev != curr.Next);

            yield break;
        }
    }
}
