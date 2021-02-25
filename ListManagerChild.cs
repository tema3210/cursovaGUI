using System;
using System.Collections.Generic;

namespace CursovaGUI
{
    class ListManagerChild : ListManager<String>
    {
        public int k {  get; set; }
        public ListManagerChild(List<String> arg) : base(arg) { }
        public override IEnumerable<String> Task()
        {
            //init iter
            var curr = this.inner;
            do
            {
                //We save next item
                var t = curr.Next;
                //then we yield an item, excluding it from a list
                var item = curr.Consume();
                if (item != null)
                {
                    yield return item;
                }
                // we fix iter: make it point into a sequence
                curr = t;

                //advance iter
                for (int i = 0; i < k; i++)
                    curr = curr.Next;
            } while (curr.Prev != curr.Next);

            var last = curr.Next;
            //the last things in a sequence
            if (last != null && last != curr)
            {
                var item = curr.Consume();
                if (item != null)
                {
                    yield return item;
                }
                //yield return curr.Consume();
                item = last.Consume();
                if (item != null)
                {
                    yield return item;
                }
            }
            else if (curr == last)
            {
                yield return curr.Data;
            }

            yield break;
        }
    }
}
