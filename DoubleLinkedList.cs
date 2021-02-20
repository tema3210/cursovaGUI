using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaGUI
{
    /// <summary>
    ///  This is double linked list that is not thread safe
    /// </summary>
    /// <typeparam name="T"> Datatype that list holds</typeparam>
    class DoubleLinkedList<T>
    {
        public DoubleLinkedList(T val)
        {
            if (val != null)
            {
                this.Data = val;
            } else
            {
                throw new ArgumentException("empty val");
            }
            
        }

        public T Data { get; set; }
        public DoubleLinkedList<T> Next;
        public DoubleLinkedList<T> Prev;
        /// <summary>
        ///  Excludes a node from a list, the list stays consistent 
        /// </summary>
        /// <returns> data </returns>
        public T Consume()
        {
            if (this.Next != null) {
                this.Next.Prev = this.Prev;
            };
            if (this.Prev != null)
            {
                this.Prev.Next = this.Next;
            };
            return this.Data;
        }
        /// <summary>
        /// create a following node
        /// </summary>
        /// <param name="val">data</param>
        public void InsertForward(T val)
        {
            var node = new DoubleLinkedList<T>(val);
            if (this.Next != null)
            {
                this.Next.Prev = node;
                node.Next = this.Next;
            }
            this.Next = node;
            node.Prev = this;
        }
        /// <summary>
        /// create a previous node
        /// </summary>
        /// <param name="val">data</param>
        public void InsertBackward(T val)
        {
            var node = new DoubleLinkedList<T>(val);
            if (this.Prev != null)
            {
                this.Prev.Next = node;
                node.Prev = this.Prev;
            }
            this.Prev = node;
            node.Next = this;
        }
    }
}
