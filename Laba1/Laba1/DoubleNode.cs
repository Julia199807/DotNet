using System;

namespace Laba1
{
    public class DoubleNode<T> : IComparable<DoubleNode<T>> where T : IComparable, new()
    {
        public DoubleNode(T data)
        {
            this.data = data;
        }
        public T data { get; internal set; }
        public DoubleNode<T> Previous { get; set; }
        public DoubleNode<T> Next { get; set; }
        
        public int CompareTo(DoubleNode<T> other)
        {
            return data.CompareTo(other.data);
        }
    }
}