using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaGUI
{
    class CyclicListManager<T>
    {
        /// <summary>
        /// argument must be not empty, else it will create ill-formed manager
        /// </summary>
        /// <param name="members"></param>
        public CyclicListManager(List<T> members)
        {
            if (members.Count > 0)
            {
                var head = new DoubleLinkedList<T>(members[0]);
                this.inner = head;
                for (int i = 1; i < members.Count; i++)
                {
                    this.inner.InsertForward(members[i]);
                    this.inner = this.inner.Next;
                }
                this.inner.Next = head;
                head.Prev = this.inner;

                this.inner = head;
            }
            else
            {
                throw new ArgumentException("empty list");
            };
        }

        public IEnumerable<T> Iter() {
            var head = this.inner;
            var curr = this.inner;
            do
            {
                yield return curr.Data;
                curr = curr.Next;
            } while (head != curr);
        }

        public virtual CyclicListManager<U> Map<U>(Func<T,U> arg) {
            var narg = new List<U>();

            foreach(var i in this.Iter())
            {
                narg.Add(arg(i));
            }
            return new CyclicListManager<U>(narg);
        }

        public virtual IEnumerable<T> Task() { yield break; }

        protected DoubleLinkedList<T> inner;
    }

    abstract class ListManager<T> : CyclicListManager<T>
    {

        public ListManager(List<T> members) : base(members) { }

        public abstract override IEnumerable<T> Task();

        public void Insert(T val)
        {
            this.inner.InsertBackward(val);
        }


    }
}
