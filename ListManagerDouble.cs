using System;
using System.Collections.Generic;

namespace CursovaGUI
{
    class ListManagerDouble : ListManager<String>
    {
        public ListManagerDouble(List<String> arg): base(arg) { }

        public override IEnumerable<String> Task()
        {
            //init iter
            var curr = this.inner;
            while (curr.Prev != curr.Next)
            {
                //advance iter
                curr = curr.Next;
                //We save next item
                var t = curr.Next;
                //then we yield an item, excluding it from a list

                double c = 0;
                if (Double.TryParse(curr.Data, out c))
                {
                    if (c < 0.0)
                    {
                        var item = curr.Consume();
                        yield return item;
                        // we fix iter: make it point into a sequence
                        curr = t;
                    }
                } else
                {
                    //ERRROR
                    throw new ArgumentException("Negatives non-number");
                }

                
            };
            //the last thing in a sequence
            yield return curr.Data;

            yield break;
        }
    }
}
