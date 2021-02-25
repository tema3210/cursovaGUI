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
            //yield the data that will otherwise be lost
            yield return curr.Consume();
            do
            {
                //advance iter
                for (int i = 0; i < k; i++)
                    curr = curr.Next;
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
            } while (curr.Prev != curr.Next);

            //the last thing in a sequence
            yield return curr.Data;

            yield break;
        }
    }
}
