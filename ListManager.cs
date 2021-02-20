using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaGUI
{
    class ListManager<T>
    {
        /// <summary>
        /// argument must be not empty, else it will create ill-formed manager
        /// </summary>
        /// <param name="members"></param>
        public ListManager(List<T> members)
        {
            if (members.Count > 0)
            {
                var head = new DoubleLinkedList<T>(members[0]);
                this.inner = head;
                for (int i = 0; i < members.Count; i++)
                {
                    this.inner.InsertForward(members[i]);
                    this.inner = this.inner.Next;
                }
                this.inner.Next = head;
                head.Prev = this.inner;
            }
            else
            {
                throw new ArgumentException("empty list");
            };
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
                var item = curr.Consume();
                if (item != null)
                {
                    yield return item;
                }
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
