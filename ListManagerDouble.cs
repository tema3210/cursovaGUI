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

            double c = 0.0;
            do
            {
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
                    c = 0.0;
                } else
                {
                    throw new ArgumentException("Negatives non-number");
                };
            } while (curr.Prev != curr.Next);

            var last = curr.Next;
            //the last things in a sequence
            if (last != null && last != curr)
            {
                var item = curr.Consume();
                if (item != null)
                {
                    if (Double.TryParse(item,out c))
                    {
                        if (c > 0.0)
                        {
                            yield return item;
                            c = 0.0;
                        }
                    }
                }
                //yield return curr.Consume();
                item = last.Consume();
                if (item != null)
                {
                    if (Double.TryParse(item, out c))
                    {
                        if (c > 0.0)
                        {
                            yield return item;
                            c = 0.0;
                        }
                    }
                }
            } else if (curr == last)
            {
                var item = curr.Data;
                if (Double.TryParse(item, out c))
                {
                    if (c > 0.0)
                    {
                        yield return item;
                        c = 0.0;
                    }
                }
            }

            yield break;
        }
    }
}
