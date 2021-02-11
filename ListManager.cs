using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaGUI
{
    class ListManager<T>
    {
        public ListManager(List<T> members)
        {
            var head = new DoubleLinkedList<T>(members[0]);
            this.inner = head;
            for (int i = 1;i<members.Count;i++)
            {
                this.inner.InsertForward(members[i]);
                this.inner = this.inner.Next;
            }
            this.inner.Next = head;
            head.Prev = this.inner;
        }

        public IEnumerable<T> Task(int k)
        {
            //init iter
            var curr = this.inner;
            while (curr.Prev != curr.Next)
            {
                //advance iter
                for (int i = 0; i < k; i++)
                    curr = curr.Next;
                //We save next item
                var t = curr.Next;
                //then we yield an item, excluding it from a list
                yield return curr.Consume();
                // we fix iter: make it point into a sequence
                curr = t;
            };
            //the last thing in a sequence
            yield return curr.Data;

            yield break;
        }

        private DoubleLinkedList<T> inner;

    }
}
