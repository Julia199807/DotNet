using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba1
{
    public class DoubleLinkedList<T>: IEnumerable<T> where T : IComparable, new()
    {
        DoubleNode<T> head; // головной/первый элемент
        DoubleNode<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке
 
        // добавление элемента
        public void Add(T data)
        {
            DoubleNode<T> node = new DoubleNode<T>(data);
 
            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            DoubleNode<T> node = new DoubleNode<T>(data);
            DoubleNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        // удаление
        public bool Remove(T data)
        {
            DoubleNode<T> current = head;
 
            // поиск удаляемого узла
            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if(current!=null)
            {
                // если узел не последний
                if(current.Next!=null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Previous;
                }
 
                // если узел не первый
                if(current.Previous!=null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }
        
              public void Output()
                {
                    if(IsEmpty) 
                        Console.Write("Empty");
                    DoubleNode<T> node = head;
                    while(node != null)
                    {
                        Console.Write("{0} ", node.data);
                        node = node.Next;
                    }
                    Console.Write('\n');
                }
              
              
              public void Sort()
              {
                  DoubleNode<T> newBegin = null;
                  DoubleNode<T> newEnd = head; //null
                  while (head != null)
                  {
                      DoubleNode<T> node = head;
                      if (head.CompareTo(newEnd) > 0)
                          newEnd = head;
                      head = head.Next;
                      if (newBegin == null || node.CompareTo(newBegin) < 0)
                      {
                          node.Next = newBegin;
                          newBegin = node;
                      }
                      else
                      {
                          DoubleNode<T> current= newBegin;
                          while (current.Next != null && node.CompareTo(current.Next) >= 0)
                          {
                              current = current.Next;
                          }
                          node.Next = current.Next;
                          current.Next = node;
                      }
                  }
                  head = newBegin;
                  tail = newEnd;
              }
              
 
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
 
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
 
        public bool Contains(T data)
        {
            DoubleNode<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
         
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoubleNode<T> current = head;
            while (current != null)
            {
                yield return current.data;
                current = current.Next;
            }
        }
 
        public IEnumerable<T> BackEnumerator()
        {
            DoubleNode<T> current = tail;
            while (current != null)
            {
                yield return current.data;
                current = current.Previous;
            }
        }
    }
}