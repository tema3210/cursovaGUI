using System;
using System.Collections.Generic;

namespace CursovaGUI
{
    class ListManagerInsert : ListManager<String>
    {
        public String el { get; set; }
        public ListManagerInsert(List<String> arg) : base(arg) { }
        public override IEnumerable<String> Task()
        {
            this.inner.InsertBackward(this.el);

            //init iter
            var curr = this.inner;

            do
            {
                //advance iter
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
